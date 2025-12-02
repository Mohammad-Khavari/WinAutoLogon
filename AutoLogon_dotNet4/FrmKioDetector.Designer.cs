namespace Auto_Logon
{
  partial class FrmKioDetector
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.lblCustom = new System.Windows.Forms.Label();
      this.lblShell = new System.Windows.Forms.Label();
      this.lblSource = new System.Windows.Forms.Label();
      this.lblAssigned = new System.Windows.Forms.Label();
      this.lblShellLuncher = new System.Windows.Forms.Label();
      this.btnExit = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblShellP = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.txtShellPath = new System.Windows.Forms.TextBox();
      this.btnShellOK = new System.Windows.Forms.Button();
      this.lblMsgG = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblCustom
      // 
      this.lblCustom.AutoSize = true;
      this.lblCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCustom.ForeColor = System.Drawing.SystemColors.ButtonFace;
      this.lblCustom.Location = new System.Drawing.Point(82, 14);
      this.lblCustom.Name = "lblCustom";
      this.lblCustom.Size = new System.Drawing.Size(41, 13);
      this.lblCustom.TabIndex = 0;
      this.lblCustom.Text = "label1";
      // 
      // lblShell
      // 
      this.lblShell.AutoSize = true;
      this.lblShell.ForeColor = System.Drawing.SystemColors.ButtonFace;
      this.lblShell.Location = new System.Drawing.Point(82, 34);
      this.lblShell.Name = "lblShell";
      this.lblShell.Size = new System.Drawing.Size(35, 13);
      this.lblShell.TabIndex = 0;
      this.lblShell.Text = "label1";
      // 
      // lblSource
      // 
      this.lblSource.AutoSize = true;
      this.lblSource.ForeColor = System.Drawing.SystemColors.ButtonFace;
      this.lblSource.Location = new System.Drawing.Point(82, 57);
      this.lblSource.Name = "lblSource";
      this.lblSource.Size = new System.Drawing.Size(35, 13);
      this.lblSource.TabIndex = 0;
      this.lblSource.Text = "label1";
      // 
      // lblAssigned
      // 
      this.lblAssigned.AutoSize = true;
      this.lblAssigned.ForeColor = System.Drawing.SystemColors.ButtonFace;
      this.lblAssigned.Location = new System.Drawing.Point(155, 77);
      this.lblAssigned.Name = "lblAssigned";
      this.lblAssigned.Size = new System.Drawing.Size(35, 13);
      this.lblAssigned.TabIndex = 0;
      this.lblAssigned.Text = "label1";
      // 
      // lblShellLuncher
      // 
      this.lblShellLuncher.AutoSize = true;
      this.lblShellLuncher.ForeColor = System.Drawing.SystemColors.ButtonFace;
      this.lblShellLuncher.Location = new System.Drawing.Point(155, 99);
      this.lblShellLuncher.Name = "lblShellLuncher";
      this.lblShellLuncher.Size = new System.Drawing.Size(35, 13);
      this.lblShellLuncher.TabIndex = 0;
      this.lblShellLuncher.Text = "label1";
      // 
      // btnExit
      // 
      this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnExit.Location = new System.Drawing.Point(178, 121);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(166, 28);
      this.btnExit.TabIndex = 1;
      this.btnExit.Text = "Close";
      this.btnExit.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 99);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(135, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Shell Launcher Configured:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 77);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(145, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Assigned Access Configured:";
      // 
      // lblShellP
      // 
      this.lblShellP.AutoSize = true;
      this.lblShellP.Location = new System.Drawing.Point(12, 57);
      this.lblShellP.Name = "lblShellP";
      this.lblShellP.Size = new System.Drawing.Size(58, 13);
      this.lblShellP.TabIndex = 4;
      this.lblShellP.Text = "Shell Path:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 34);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(64, 13);
      this.label4.TabIndex = 5;
      this.label4.Text = "Shell Name:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 14);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(71, 13);
      this.label5.TabIndex = 6;
      this.label5.Text = "Custom Shell:";
      // 
      // txtShellPath
      // 
      this.txtShellPath.BackColor = System.Drawing.Color.Pink;
      this.txtShellPath.Location = new System.Drawing.Point(66, 54);
      this.txtShellPath.Name = "txtShellPath";
      this.txtShellPath.Size = new System.Drawing.Size(451, 20);
      this.txtShellPath.TabIndex = 7;
      this.txtShellPath.Visible = false;
      // 
      // btnShellOK
      // 
      this.btnShellOK.Location = new System.Drawing.Point(520, 54);
      this.btnShellOK.Name = "btnShellOK";
      this.btnShellOK.Size = new System.Drawing.Size(30, 23);
      this.btnShellOK.TabIndex = 8;
      this.btnShellOK.Text = "OK";
      this.btnShellOK.UseVisualStyleBackColor = true;
      this.btnShellOK.Visible = false;
      // 
      // lblMsgG
      // 
      this.lblMsgG.AutoSize = true;
      this.lblMsgG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMsgG.ForeColor = System.Drawing.Color.LimeGreen;
      this.lblMsgG.Location = new System.Drawing.Point(206, 77);
      this.lblMsgG.Name = "lblMsgG";
      this.lblMsgG.Size = new System.Drawing.Size(192, 25);
      this.lblMsgG.TabIndex = 9;
      this.lblMsgG.Text = "KIOSK Activated!";
      this.lblMsgG.Visible = false;
      // 
      // FrmKioDetector
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnExit;
      this.ClientSize = new System.Drawing.Size(562, 154);
      this.ControlBox = false;
      this.Controls.Add(this.lblMsgG);
      this.Controls.Add(this.btnShellOK);
      this.Controls.Add(this.txtShellPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lblShellP);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.btnExit);
      this.Controls.Add(this.lblShellLuncher);
      this.Controls.Add(this.lblAssigned);
      this.Controls.Add(this.lblSource);
      this.Controls.Add(this.lblShell);
      this.Controls.Add(this.lblCustom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmKioDetector";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FrmKioDetector";
      this.Load += new System.EventHandler(this.FrmKioDetector_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblCustom;
    private System.Windows.Forms.Label lblShell;
    private System.Windows.Forms.Label lblSource;
    private System.Windows.Forms.Label lblAssigned;
    private System.Windows.Forms.Label lblShellLuncher;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblShellP;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtShellPath;
    private System.Windows.Forms.Button btnShellOK;
    private System.Windows.Forms.Label lblMsgG;
  }
}