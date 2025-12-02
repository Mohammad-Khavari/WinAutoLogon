using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_Logon
{
  public partial class FrmMain : Form
  {
    private readonly WindowsApiHelper WinAPI = new WindowsApiHelper();

    public FrmMain()
    {
      InitializeComponent();
      
      btnDecrypt.Click += (s,e)=>CheckAndDecrypt();
      btnSetAutoLogon.Click += (s, e) => SetAutoLogon.SetAutoLogonConfig(txtUserName.Text,txtDomain.Text,txtPassword.Text,CheckAndDecrypt);
    }

    private void CheckAndDecrypt()
    {
      try
      {
        if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
        {
          DialogResult result = MessageBox.Show("This application requires administrator privileges to function properly.\n " +
                                                "Would you like to restart the application with admin rights?",
                                                "Administrator Required", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
          if (result == DialogResult.Yes)
          {
              this.Close();
              Application.Exit();

            Thread.Sleep(1000); // Wait for the form to close

            try
            {
              // Restart with admin rights
              ProcessStartInfo processInfo = new ProcessStartInfo
              {
                UseShellExecute = true,
                FileName = Assembly.GetExecutingAssembly().Location,
                Verb = "runas" // This triggers UAC prompt
              };
              
              Process.Start(processInfo);
            }
            catch (Exception ex)
            {
              MessageBox.Show($"Failed to restart with admin privileges: {ex.Message}",
                  "Error",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }
          }
          else
          {
            return;
          }
        }

        string regPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";
        string username = "Not set";
        string domain = "Not set";
        string debugInfo = "Registry Debug Info:\n";

        // Check 64-bit view
        using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
            .OpenSubKey(regPath, false))
        {
          if (key64 != null)
          {
            debugInfo += "64-bit view:\n";
            username = GetRegistryValue(key64, "DefaultUserName", ref debugInfo);
            domain = GetRegistryValue(key64, "DefaultDomainName", ref debugInfo);
          }
          else
          {
            debugInfo += "64-bit view: Key not found\n";
          }
        }

        #region 32-bit (optional) - need to test on 32-bit OS

        // Check 32-bit view if 64-bit didn’t work
        //if (username == "Not set" || domain == "Not set")
        //{
        //  using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
        //      .OpenSubKey(regPath, false))
        //  {
        //    if (key32 != null)
        //    {
        //      debugInfo += "32-bit view:\n";
        //      username = GetRegistryValue(key32, "DefaultUserName", ref debugInfo);
        //      domain = GetRegistryValue(key32, "DefaultDomainName", ref debugInfo);
        //    }
        //    else
        //    {
        //      debugInfo += "32-bit view: Key not found\n";
        //    }
        //  }
        //}

        //MessageBox.Show(debugInfo, "Registry Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        #endregion

        lblUsername.Text = $"Username: {username}";
        lblDomain.Text = $"Domain: {domain}";

        // Check AutoAdminLogon (using 64-bit view as default)
        using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
            .OpenSubKey(regPath, false))
        {
          object autoAdminLogon = GetRegistryValue(key64,"AutoAdminLogon",ref debugInfo);
          if (autoAdminLogon == null || autoAdminLogon.ToString() != "1")
          {
            picInactive.Visible = true;
            picActive.Visible = false;
            btnDeactive.Enabled = false;
            //MessageBox.Show("Autologon is not enabled (AutoAdminLogon != 1).",
            //  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
          else
          {
            
            picInactive.Visible = false;
            picActive.Visible = true;
            btnDeactive.Enabled = true;
            //MessageBox.Show("Auto Logon is active!");
          }
        }
        
        string password = GetAutologonPassword();

        lblPassword.Text = $"Password: {(password != null ? password : "Not found or failed to decrypt")}";
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error: {ex.Message}",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        lblUsername.Text = "Username: Error";
        lblDomain.Text = "Domain: Error";
        lblPassword.Text = "Password: Error";
      }
    }

    private string GetRegistryValue(RegistryKey key, string valueName, ref string debugInfo)
    {
      object valueObj = key.GetValue(valueName, "Not set");
      string value = "Not set";
      string valueKind = "N/A";

      // Check if the value exists before getting its kind
      if (Array.Exists(key.GetValueNames(), name => name.Equals(valueName, StringComparison.OrdinalIgnoreCase)))
      {
        valueKind = key.GetValueKind(valueName).ToString();
        if (valueObj != null && valueObj.ToString() != "Not set")
        {
          value = valueObj.ToString().Trim();
          if (string.IsNullOrEmpty(value)) value = "Empty string detected";
        }
      }
      else
      {
        valueKind = "Not present";
      }

      debugInfo += $"{valueName} ({valueKind}): '{valueObj}'\n";
      return value;
    }

    private string GetAutologonPassword()
    {
      IntPtr policyHandle = IntPtr.Zero;
      
      if (!WinAPI.OpenPolicy(null,out policyHandle))
      {
        throw new Exception($"LsaOpenPolicy failed: {Marshal.GetLastWin32Error()}");
      }

      try
      {
        if (WinAPI.RetrievePrivateData(policyHandle, "DefaultPassword", out string pw))
        {
          return pw; // Return the retrieved pw or null if not found
        }

        return null; // Return null if the pw was not found

      }
      finally
      {
        WinAPI.CloseHandle(policyHandle);
        //LsaClose(policyHandle);
      }
    }

    #region Old method to set autologon
    //private void SetAutoLogon()
    //{
    //  try
    //  {
    //    if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
    //    {
    //      MessageBox.Show("This program must be run with administrative privileges.",
    //          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //      return;
    //    }
    //    string regPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";
    //    string username = txtUserName.Text;
    //    string domain = txtDomain.Text;
    //    string pw = txtPassword.Text;

    //    // Check if any of the fields are empty
    //    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(domain) || string.IsNullOrEmpty(pw))
    //    {
    //      MessageBox.Show("Please fill in all fields.",
    //          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //      return;
    //    }

    //    // Check if the pw is too long
    //    if (pw.Length > 127)
    //    {
    //      MessageBox.Show("The pw is too long (max 127 characters).",
    //          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //      return;
    //    }

    //    // Set the registry values
    //    using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
    //                .OpenSubKey(regPath, writable: true))
    //    {
    //      if (key == null)
    //      {
    //        MessageBox.Show("Error: Could not open registry key.",
    //            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        return;
    //      }

    //      // TODO
    //      key.SetValue("DefaultUserName", username,RegistryValueKind.String);
    //      key.SetValue("DefaultDomainName", string.IsNullOrEmpty(domain) ? "." : domain, RegistryValueKind.String);
    //      key.SetValue("AutoAdminLogon", 1, RegistryValueKind.String);
    //      //key.SetValue("ForceAutoLogon", 1);
    //      //key.SetValue("DefaultPassword", pw);
    //    }

    //    // Encrypt and set the pw in LSA
    //    IntPtr policyHandle = IntPtr.Zero;
    //    LSA_OBJECT_ATTRIBUTES objectAttributes = new LSA_OBJECT_ATTRIBUTES();
    //    objectAttributes.Length = 0;
    //    LSA_UNICODE_STRING systemName = new LSA_UNICODE_STRING();
    //    uint result = LsaOpenPolicy(ref systemName, ref objectAttributes, POLICY_GET_PRIVATE_INFORMATION | POLICY_CREATE_SECRET, out policyHandle);

    //    if (result != STATUS_SUCCESS)
    //    {
    //      throw new Exception($"LsaOpenPolicy failed: {LsaNtStatusToWinError(result)}");
    //    }

    //    try
    //    {
    //      LSA_UNICODE_STRING keyName = CreateLsaUnicodeString("DefaultPassword");
    //      LSA_UNICODE_STRING secretData = CreateLsaUnicodeString(pw);
    //      result = LsaStorePrivateData(policyHandle, ref keyName, ref secretData);
    //      if (result != STATUS_SUCCESS)
    //      {
    //        throw new Exception($"LsaStorePrivateData failed: {LsaNtStatusToWinError(result)}");
    //      }
    //      MessageBox.Show("Autologon configured successfully!",
    //                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //      CheckAndDecrypt(); // Refresh the display
    //    }
    //    finally
    //    {
    //      LsaClose(policyHandle);
    //    }

    //  }
    //  catch (Exception ex)
    //  {
    //    MessageBox.Show($"Error: {ex.Message}",
    //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //  }
    //}
    #endregion
    
    private void btnExit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void BtnShowPW_Click(object sender, EventArgs e)
    {
      if (!txtPassword.UseSystemPasswordChar)
      {
        txtPassword.UseSystemPasswordChar = true;
        BtnShowPW.Text = "👁️";
        BtnShowPW.ForeColor = System.Drawing.Color.Red;
       
      }
      else
      {
        txtPassword.UseSystemPasswordChar = false;
        BtnShowPW.Text = "👁️";
        BtnShowPW.ForeColor = System.Drawing.Color.Green;

      }
    }

    private void btnDeactive_Click_1(object sender, EventArgs e)
    {
      DeactivateAutoLogon.Deactivate();
    }

    private string[] GetUsernameAndDomainName() 
    {
      try
      {
        string[] strings = new string[2];
        strings[0] = WindowsIdentity.GetCurrent().Name.Split('\\')[1];
        strings[1] = WindowsIdentity.GetCurrent().Name.Split('\\')[0];
        return strings;
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error: {ex.Message}",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return new string[] { "Error", "Error" };
      }
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
      string[] info = GetUsernameAndDomainName();

      txtUserName.Text = info[0];
      txtDomain.Text = info[1];
      BtnShowPW.Text = "👁️";
      BtnShowPW.ForeColor = System.Drawing.Color.Red;
      //txtUserName.Text = Environment.UserName;
      //txtDomain.Text = Environment.UserDomainName;
      lblPassword.Click += (s, ev) => CopyToClipboard(lblPassword);
      lblDomain.Click += (s, ev) => CopyToClipboard(lblDomain);
      lblUsername.Click += (s, ev) => CopyToClipboard(lblUsername);

      //FrmKioDetector  frmKioDetector = new FrmKioDetector();
      //frmKioDetector.Show();
    }

    private async void CopyToClipboard(Label label)
    {
      string[] parts = label.Text.Split(':');

      if(parts.Length > 1 && !string.IsNullOrWhiteSpace(parts[1]))
      {
        if (parts[1].StartsWith(" Not"))
        {
          return;
        }
        Clipboard.SetText(parts[1].Trim());
        
        lblCopyMsg.Visible = true;
        await Task.Delay(2000);
        lblCopyMsg.Visible = false;
      }
      else
      {
        return;
      }
    }

    private void txtPassword_TextChanged(object sender, EventArgs e)
    {
      // PW Check Regex: At least 8 characters, one uppercase, one lowercase, one number, one special character
      //Regex.IsMatch(txtPassword.Text, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z0-9]).{5,}$");
      btnSetAutoLogon.Enabled = txtPassword.Text.Length >= 3;
    }

    private void btnCheckKioskMode_Click(object sender, EventArgs e)
    {
      using FrmKioDetector kmd = new FrmKioDetector();
      {
        kmd.ShowDialog();
      }
    }
  }
}