using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;


namespace Auto_Logon
{
  public partial class FrmMain : Form
  {
    #region Windows API structures and imports
    // Windows API structures and imports
    [StructLayout(LayoutKind.Sequential)]
    private struct LSA_OBJECT_ATTRIBUTES
    {
      public int Length;
      public IntPtr RootDirectory;
      public IntPtr ObjectName;
      public uint Attributes;
      public IntPtr SecurityDescriptor;
      public IntPtr SecurityQualityOfService;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct LSA_UNICODE_STRING
    {
      public ushort Length;
      public ushort MaximumLength;
      public IntPtr Buffer;
    }

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern uint LsaOpenPolicy(
        ref LSA_UNICODE_STRING systemName,
        ref LSA_OBJECT_ATTRIBUTES objectAttributes,
        uint desiredAccess,
        out IntPtr policyHandle);

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern uint LsaRetrievePrivateData(
        IntPtr policyHandle,
        ref LSA_UNICODE_STRING keyName,
        out IntPtr privateData);

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern uint LsaStorePrivateData(
        IntPtr policyHandle,
        ref LSA_UNICODE_STRING keyName,
        ref LSA_UNICODE_STRING privateData);

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern uint LsaClose(IntPtr objectHandle);

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern uint LsaNtStatusToWinError(uint status);

    private const uint STATUS_SUCCESS = 0x00000000;
    private const uint POLICY_GET_PRIVATE_INFORMATION = 0x00000004;
    private const uint POLICY_CREATE_SECRET = 0x00000008;
    #endregion
    public FrmMain()
    {
      InitializeComponent();
      //CheckAndDecrypt();
      btnDecrypt.Click += (s,e)=>CheckAndDecrypt();
      btnSetAutoLogon.Click += (s, e) => SetAutoLogon();
      
    }

    private void BtnDeactive_Click(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }

    private void BtnSetAutoLogon_Click(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }

    private void CheckAndDecrypt()
    {
      try
      {
        if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
        {
          MessageBox.Show("This program must be run with administrative privileges.",
              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
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
            MessageBox.Show("Autologon is not enabled (AutoAdminLogon != 1).",
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
          else
          {
            MessageBox.Show("Auto Logon is active!");
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

    private static string GetAutologonPassword()
    {
      IntPtr policyHandle = IntPtr.Zero;
      LSA_OBJECT_ATTRIBUTES objectAttributes = new LSA_OBJECT_ATTRIBUTES();
      objectAttributes.Length = 0;
      objectAttributes.RootDirectory = IntPtr.Zero;
      objectAttributes.Attributes = 0;
      objectAttributes.SecurityDescriptor = IntPtr.Zero;
      objectAttributes.SecurityQualityOfService = IntPtr.Zero;

      LSA_UNICODE_STRING systemName = new LSA_UNICODE_STRING();
      uint result = LsaOpenPolicy(ref systemName, ref objectAttributes, POLICY_GET_PRIVATE_INFORMATION, out policyHandle);

      if (result != STATUS_SUCCESS)
      {
        throw new Exception($"LsaOpenPolicy failed: {LsaNtStatusToWinError(result)}");
      }

      try
      {
        string keyNameStr = "DefaultPassword";
        LSA_UNICODE_STRING keyName = CreateLsaUnicodeString(keyNameStr);
        IntPtr privateData = IntPtr.Zero;

        result = LsaRetrievePrivateData(policyHandle, ref keyName, out privateData);

        if (result != STATUS_SUCCESS)
        {
          return null;
        }

        if (privateData != IntPtr.Zero)
        {
          LSA_UNICODE_STRING secretData = (LSA_UNICODE_STRING)Marshal.PtrToStructure(privateData, typeof(LSA_UNICODE_STRING));
          return Marshal.PtrToStringUni(secretData.Buffer, secretData.Length / 2);
        }
      }
      finally
      {
        LsaClose(policyHandle);
      }

      return null;
    }

    private void SetAutoLogon()
    {
      try
      {
        if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
        {
          MessageBox.Show("This program must be run with administrative privileges.",
              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        string regPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";
        string username = txtUserName.Text;
        string domain = txtDomain.Text;
        string password = txtPassword.Text;

        // Check if any of the fields are empty
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(domain) || string.IsNullOrEmpty(password))
        {
          MessageBox.Show("Please fill in all fields.",
              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        // Check if the password is too long
        if (password.Length > 127)
        {
          MessageBox.Show("The password is too long (max 127 characters).",
              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        // Set the registry values
        using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                    .OpenSubKey(regPath, writable: true))
        {
          if (key == null)
          {
            MessageBox.Show("Error: Could not open registry key.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }

          // TODO
          key.SetValue("DefaultUserName", username,RegistryValueKind.String);
          key.SetValue("DefaultDomainName", string.IsNullOrEmpty(domain) ? "." : domain, RegistryValueKind.String);
          key.SetValue("AutoAdminLogon", 1, RegistryValueKind.String);
          //key.SetValue("ForceAutoLogon", 1);
          //key.SetValue("DefaultPassword", password);
        }

        // Encrypt and set the password in LSA
        IntPtr policyHandle = IntPtr.Zero;
        LSA_OBJECT_ATTRIBUTES objectAttributes = new LSA_OBJECT_ATTRIBUTES();
        objectAttributes.Length = 0;
        LSA_UNICODE_STRING systemName = new LSA_UNICODE_STRING();
        uint result = LsaOpenPolicy(ref systemName, ref objectAttributes, POLICY_GET_PRIVATE_INFORMATION | POLICY_CREATE_SECRET, out policyHandle);

        if (result != STATUS_SUCCESS)
        {
          throw new Exception($"LsaOpenPolicy failed: {LsaNtStatusToWinError(result)}");
        }

        try
        {
          LSA_UNICODE_STRING keyName = CreateLsaUnicodeString("DefaultPassword");
          LSA_UNICODE_STRING secretData = CreateLsaUnicodeString(password);
          result = LsaStorePrivateData(policyHandle, ref keyName, ref secretData);
          if (result != STATUS_SUCCESS)
          {
            throw new Exception($"LsaStorePrivateData failed: {LsaNtStatusToWinError(result)}");
          }
          MessageBox.Show("Autologon configured successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          CheckAndDecrypt(); // Refresh the display
        }
        finally
        {
          LsaClose(policyHandle);
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error: {ex.Message}",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static LSA_UNICODE_STRING CreateLsaUnicodeString(string value)
    {
      LSA_UNICODE_STRING unicodeString = new LSA_UNICODE_STRING();
      unicodeString.Buffer = Marshal.StringToHGlobalUni(value);
      unicodeString.Length = (ushort)(value.Length * 2);
      unicodeString.MaximumLength = (ushort)(unicodeString.Length + 2);
      return unicodeString;
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void BtnShowPW_Click(object sender, EventArgs e)
    {
      txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
    }

    private void btnDeactive_Click_1(object sender, EventArgs e)
    {
      DeactivateAutoLogon.Deactivate();
    }
  }
}