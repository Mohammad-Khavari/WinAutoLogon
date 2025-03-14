using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Auto_Logon
{
  internal static class DeactivateAutoLogon
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

    private static LSA_UNICODE_STRING CreateLsaUnicodeString(string value)
    {
      LSA_UNICODE_STRING unicodeString = new LSA_UNICODE_STRING();
      unicodeString.Buffer = Marshal.StringToHGlobalUni(value);
      unicodeString.Length = (ushort)(value.Length * 2);
      unicodeString.MaximumLength = (ushort)(unicodeString.Length + 2);
      return unicodeString;
    }


    public static void Deactivate()
    {
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
        LSA_OBJECT_ATTRIBUTES objectAttributes = new LSA_OBJECT_ATTRIBUTES();
        objectAttributes.Length = 0;

        LSA_UNICODE_STRING systemName = new LSA_UNICODE_STRING();
        uint result = LsaOpenPolicy(ref systemName, ref objectAttributes,
            POLICY_GET_PRIVATE_INFORMATION | POLICY_CREATE_SECRET, out policyHandle);

        if (result != STATUS_SUCCESS)
        {
          throw new Exception($"LsaOpenPolicy failed: {LsaNtStatusToWinError(result)}");
        }

        try
        {
          LSA_UNICODE_STRING keyName = CreateLsaUnicodeString("DefaultPassword");
          // Passing null to LsaStorePrivateData removes the secret
          LSA_UNICODE_STRING privateData = new LSA_UNICODE_STRING(); // Empty structure
          result = LsaStorePrivateData(policyHandle, ref keyName, ref privateData);

          if (result != STATUS_SUCCESS)
          {
            MessageBox.Show($"Failed to clear password from LSA: {LsaNtStatusToWinError(result)}",
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
        }
        finally
        {
          LsaClose(policyHandle);
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
