using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Auto_Logon
{
  internal static class DeactivateAutoLogon
  {

    public static void Deactivate()
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

        // Update registry to disable autologon
        string regPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";
        using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
            .OpenSubKey(regPath, writable: true))
        {
          if (key == null)
          {
            MessageBox.Show("Could not open registry key for writing.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }

          key.SetValue("AutoAdminLogon", "0", RegistryValueKind.String);
        }

        // Optional: Clear the password from LSA
        IntPtr policyHandle = IntPtr.Zero;
   
        if (!WinAPI.OpenPolicy(null, out policyHandle))
        {
          throw new Exception($"LsaOpenPolicy failed: {Marshal.GetLastWin32Error()}");
        }

        try
        {
          // Passiing null value to StorePrivateData removes the secret

          if (!WinAPI.StorePrivateData(policyHandle, "DefaultPassword", null))
          {
            MessageBox.Show($"Failed to clear password from LSA: {Marshal.GetLastWin32Error()}",
               "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }

        }
        finally
        {
          WinAPI.CloseHandle(policyHandle);
        }

        MessageBox.Show("Autologon deactivated successfully!",
            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error deactivating autologon: {ex.Message}",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
