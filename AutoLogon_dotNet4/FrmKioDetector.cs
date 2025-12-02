using Microsoft.Win32;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_Logon
{
  public partial class FrmKioDetector : Form
  {
    Button btnActiveInactiveKiosk;
    public FrmKioDetector()
    {
      InitializeComponent();

    }


    private async void FrmKioDetector_Load(object sender, EventArgs e)
    {
      Cursor = System.Windows.Forms.Cursors.WaitCursor;
      btnActiveInactiveKiosk = new Button();
      try
      {

        var result = await Task.Run(() => KioskDetector.Detect());

        //var sb = new StringBuilder()
        //  .AppendLine($"Custom shell override: {result.HasCustomShellOverride}")
        //  .AppendLine($"Effective shell      : {result.EffectiveShell ?? "(net set)"}")
        //  .AppendLine($"Shell source         : {result.ShellSource ?? "(n/a)"}")
        //  .AppendLine($"Assigned Access (koisk) : {result.AssignedAccessConfigured}")
        //  .AppendLine($"Shell Launcher       : {result.ShellLauncherConfigured}")
        //  .AppendLine()
        //  .AppendLine(result.Notes ?? string.Empty);

        //MessageBox.Show(this, sb.ToString(), "Kiosk Mode Detection", MessageBoxButtons.OK,MessageBoxIcon.Information );

        lblSource.Text = result.ShellSource ?? "(n/a)";
        lblCustom.Text = result.HasCustomShellOverride ? "Active" : "Inactive";
        lblShell.Text = result.EffectiveShell ?? "(not set)";
        lblAssigned.Text = result.AssignedAccessConfigured ? "Enabled" : "Disabled";
        lblShellLuncher.Text = result.ShellLauncherConfigured ? "Enabled" : "Disabled";
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, "Detection failed: \n\r" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        Cursor = System.Windows.Forms.Cursors.Default;
        lblSource.ForeColor = Color.Black;
        lblCustom.ForeColor = lblCustom.Text.Contains("Active") ? Color.LightGreen : Color.Red;
        lblShell.ForeColor = Color.Blue;
        lblAssigned.ForeColor = Color.Orange;
        lblShellLuncher.ForeColor = Color.Orange;

        if (this.Controls["btnActiveInactive"] == null)
        {
          btnActiveInactiveKiosk.Location = new Point(lblCustom.Right + 5, lblCustom.Top - 5);
          btnActiveInactiveKiosk.Text = lblCustom.Text.Contains("Active") ? "Disable" : "Enable";
          btnActiveInactiveKiosk.Click += (s, e) => ActivateDeactivate();
          btnActiveInactiveKiosk.Name = "btnActiveInactive";
          this.Controls.Add(btnActiveInactiveKiosk);
        }
        else
        {
          bool isActive = lblCustom.Text.Contains("Active");
          this.Controls["btnActiveInactive"].Location = new Point(lblCustom.Right + 6, lblCustom.Top - 5);
          this.Controls["btnActiveInactive"].BringToFront();
          this.Controls["btnActiveInactive"].Text = isActive ? "Disable" : "Enable";
        }
      }

    }
    private void ActivateDeactivate()
    {
      try
      {
        bool usecurrentUser = false;
        bool deactivate = false;
        var resutl = DialogResult.Cancel;
        if (lblCustom.Text.Contains("Active"))
        {
          resutl = MessageBox.Show("Do you want to deactive the Kiosk mode for this user?", "Which User?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        else
        {
          resutl = MessageBox.Show("Do you want to active the Kiosk mode only for this user?", "Which User?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }


        if (resutl == DialogResult.Yes)
        {
          usecurrentUser = true;
          deactivate = true;
        }
        RegistryKey root = usecurrentUser ? Registry.CurrentUser : Registry.LocalMachine;

        using (var key = root.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon", writable: true))
        {
          if (key != null && key.GetValue("Shell") != null && deactivate)
          {
            bool shellVal = key.GetValue("Shell").ToString().Equals("explorer.exe", StringComparison.OrdinalIgnoreCase);
            if (!shellVal)
            {
              key.DeleteValue("Shell");
              FrmKioDetector_Load(null, null);
            }
            else
            {
              resutl = MessageBox.Show($"Shell has already a value {key.GetValue("Shell")}, Do you want to change it?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
              if (resutl == DialogResult.Yes)
              {
                ShowInput();
              }
            }
          }
          else
          {
            ShowInput();
          }
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error happened!\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private async Task AddShellValue()
    {
      try
      {
        RegistryKey root = true ? Registry.CurrentUser : Registry.LocalMachine;

        using (var key = root.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon", writable: true))
        {

          key.SetValue("Shell", txtShellPath.Text);
          lblMsgG.Visible = true;
          await Task.Delay(2000);
          lblMsgG.Visible = false;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error happened while adding registery value\n{ex.Message}", "Registery Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

      }
      finally
      {
        txtShellPath.Text = string.Empty;
        txtShellPath.Visible = false;
        btnShellOK.Visible = false;
        FrmKioDetector_Load(null, null);
      }
    }

    private void ShowInput()
    {
      btnShellOK.Visible = true;
      txtShellPath.Visible = true;
      txtShellPath.Focus();
      btnShellOK.Click += async (e, s) => await AddShellValue();
    }
  }
}
