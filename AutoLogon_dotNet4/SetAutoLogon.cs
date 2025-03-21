using Microsoft.Win32;
using System;
using System.Security.Principal;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Auto_Logon
{
  internal static class SetAutoLogon
  {
    internal static void SetAutoLogonConfig(string uname, string domainName, string pw)
    {
      WindowsApiHelper WinAPI = new WindowsApiHelper();
      try
      {
        if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
        {
          MessageBox.Show("This program must be run with administrative privileges.",
              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        string regPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";
        string username = uname;
        string domain = domainName;
        string password = pw;

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
          key.SetValue("DefaultUserName", username, RegistryValueKind.String);
          key.SetValue("DefaultDomainName", string.IsNullOrEmpty(domain) ? "." : domain, RegistryValueKind.String);
          key.SetValue("AutoAdminLogon", 1, RegistryValueKind.String);
          //key.SetValue("ForceAutoLogon", 1);
          //key.SetValue("DefaultPassword", password);
        }

        // Encrypt and set the password in LSA
        IntPtr policyHandle = IntPtr.Zero;
        //LSA_OBJECT_ATTRIBUTES objectAttributes = new LSA_OBJECT_ATTRIBUTES();
        //objectAttributes.Length = 0;
        //LSA_UNICODE_STRING systemName = new LSA_UNICODE_STRING();
        //uint result = LsaOpenPolicy(ref systemName, ref objectAttributes, POLICY_GET_PRIVATE_INFORMATION | POLICY_CREATE_SECRET, out policyHandle);

        if (!WinAPI.OpenPolicy(null,out policyHandle))
        {
          throw new Exception($"LsaOpenPolicy failed: {Marshal.GetLastWin32Error()}");
        }

        try
        {
          // Store the password
          if (!WinAPI.StorePrivateData(policyHandle, "DefaultPassword", password))
          {
            throw new Exception($"LsaStorePrivateData failed: {Marshal.GetLastWin32Error()}");
          }
          //LSA_UNICODE_STRING keyName = CreateLsaUnicodeString("DefaultPassword");
          //LSA_UNICODE_STRING secretData = CreateLsaUnicodeString(password);
          //result = LsaStorePrivateData(policyHandle, ref keyName, ref secretData);
          //if (result != STATUS_SUCCESS)
          //{
          //  throw new Exception($"LsaStorePrivateData failed: {LsaNtStatusToWinError(result)}");
          //}
          MessageBox.Show("Autologon configured successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          //CheckAndDecrypt(); // Refresh the display
        }
        finally
        {
         WinAPI.CloseHandle(policyHandle);
          //LsaClose(policyHandle);
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error: {ex.Message}",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
