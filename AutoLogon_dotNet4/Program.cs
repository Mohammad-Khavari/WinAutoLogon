using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Auto_Logon
{
  internal static class Program
  {
    [DllImport("user32.dll")]
    private static extern bool SetForgroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private const int SW_SHOW = 9;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      const string appName = "AutoLogonByMK2025";
      using (Mutex mutex = new Mutex(true, appName, out bool createdNew))
      {
        if (!createdNew)
        {
          //find and activate existing instance

          MessageBox.Show("Another instance of the application is already running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

          Process current = Process.GetCurrentProcess();
          foreach (Process process in Process.GetProcessesByName(current.ProcessName))
          {
            if (process.Id != current.Id)
            {
              ShowWindow(process.MainWindowHandle, SW_SHOW);
              SetForgroundWindow(process.MainWindowHandle);
              break;
            }
          }
          return;
        }
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FrmMain());
      }
    }
  }
}
