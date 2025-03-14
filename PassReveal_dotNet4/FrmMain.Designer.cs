namespace Auto_Logon
{
  partial class FrmMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.btnDecrypt = new System.Windows.Forms.Button();
      this.lblPassword = new System.Windows.Forms.Label();
      this.lblDomain = new System.Windows.Forms.Label();
      this.lblUsername = new System.Windows.Forms.Label();
      this.BtnShowPW = new System.Windows.Forms.Button();
      this.btnExit = new System.Windows.Forms.Button();
      this.btnDeactive = new System.Windows.Forms.Button();
      this.btnSetAutoLogon = new System.Windows.Forms.Button();
      this.lblPW = new System.Windows.Forms.Label();
      this.lblDM = new System.Windows.Forms.Label();
      this.lblUName = new System.Windows.Forms.Label();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.txtDomain = new System.Windows.Forms.TextBox();
      this.txtUserName = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
      this.splitContainer1.Panel1.Controls.Add(this.btnDecrypt);
      this.splitContainer1.Panel1.Controls.Add(this.lblPassword);
      this.splitContainer1.Panel1.Controls.Add(this.lblDomain);
      this.splitContainer1.Panel1.Controls.Add(this.lblUsername);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.BtnShowPW);
      this.splitContainer1.Panel2.Controls.Add(this.btnExit);
      this.splitContainer1.Panel2.Controls.Add(this.btnDeactive);
      this.splitContainer1.Panel2.Controls.Add(this.btnSetAutoLogon);
      this.splitContainer1.Panel2.Controls.Add(this.lblPW);
      this.splitContainer1.Panel2.Controls.Add(this.lblDM);
      this.splitContainer1.Panel2.Controls.Add(this.lblUName);
      this.splitContainer1.Panel2.Controls.Add(this.txtPassword);
      this.splitContainer1.Panel2.Controls.Add(this.txtDomain);
      this.splitContainer1.Panel2.Controls.Add(this.txtUserName);
      this.splitContainer1.Size = new System.Drawing.Size(384, 273);
      this.splitContainer1.SplitterDistance = 121;
      this.splitContainer1.TabIndex = 3;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::Auto_Logon.Properties.Resources._lock;
      this.pictureBox1.Location = new System.Drawing.Point(272, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(109, 115);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 12;
      this.pictureBox1.TabStop = false;
      // 
      // btnDecrypt
      // 
      this.btnDecrypt.Location = new System.Drawing.Point(10, 87);
      this.btnDecrypt.Name = "btnDecrypt";
      this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
      this.btnDecrypt.TabIndex = 11;
      this.btnDecrypt.Text = "Refresh";
      this.btnDecrypt.UseVisualStyleBackColor = true;
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Location = new System.Drawing.Point(10, 61);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(56, 13);
      this.lblPassword.TabIndex = 10;
      this.lblPassword.Text = "Password:";
      // 
      // lblDomain
      // 
      this.lblDomain.AutoSize = true;
      this.lblDomain.Location = new System.Drawing.Point(10, 39);
      this.lblDomain.Name = "lblDomain";
      this.lblDomain.Size = new System.Drawing.Size(46, 13);
      this.lblDomain.TabIndex = 9;
      this.lblDomain.Text = "Domain:";
      // 
      // lblUsername
      // 
      this.lblUsername.AutoSize = true;
      this.lblUsername.Location = new System.Drawing.Point(10, 17);
      this.lblUsername.Name = "lblUsername";
      this.lblUsername.Size = new System.Drawing.Size(58, 13);
      this.lblUsername.TabIndex = 8;
      this.lblUsername.Text = "Username:";
      // 
      // BtnShowPW
      // 
      this.BtnShowPW.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.BtnShowPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnShowPW.ForeColor = System.Drawing.Color.Blue;
      this.BtnShowPW.Location = new System.Drawing.Point(272, 65);
      this.BtnShowPW.Margin = new System.Windows.Forms.Padding(0);
      this.BtnShowPW.Name = "BtnShowPW";
      this.BtnShowPW.Size = new System.Drawing.Size(39, 22);
      this.BtnShowPW.TabIndex = 17;
      this.BtnShowPW.Text = "👁️";
      this.BtnShowPW.UseVisualStyleBackColor = false;
      this.BtnShowPW.Click += new System.EventHandler(this.BtnShowPW_Click);
      // 
      // btnExit
      // 
      this.btnExit.Location = new System.Drawing.Point(225, 102);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(75, 23);
      this.btnExit.TabIndex = 17;
      this.btnExit.Text = "Exit";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // btnDeactive
      // 
      this.btnDeactive.Location = new System.Drawing.Point(144, 102);
      this.btnDeactive.Name = "btnDeactive";
      this.btnDeactive.Size = new System.Drawing.Size(75, 23);
      this.btnDeactive.TabIndex = 18;
      this.btnDeactive.Text = "Deactivate";
      this.btnDeactive.UseVisualStyleBackColor = true;
      this.btnDeactive.Click += new System.EventHandler(this.btnDeactive_Click_1);
      // 
      // btnSetAutoLogon
      // 
      this.btnSetAutoLogon.Location = new System.Drawing.Point(63, 102);
      this.btnSetAutoLogon.Name = "btnSetAutoLogon";
      this.btnSetAutoLogon.Size = new System.Drawing.Size(75, 23);
      this.btnSetAutoLogon.TabIndex = 19;
      this.btnSetAutoLogon.Text = "Activate";
      this.btnSetAutoLogon.UseVisualStyleBackColor = true;
      // 
      // lblPW
      // 
      this.lblPW.AutoSize = true;
      this.lblPW.Location = new System.Drawing.Point(10, 68);
      this.lblPW.Name = "lblPW";
      this.lblPW.Size = new System.Drawing.Size(56, 13);
      this.lblPW.TabIndex = 14;
      this.lblPW.Text = "Password:";
      // 
      // lblDM
      // 
      this.lblDM.AutoSize = true;
      this.lblDM.Location = new System.Drawing.Point(10, 42);
      this.lblDM.Name = "lblDM";
      this.lblDM.Size = new System.Drawing.Size(46, 13);
      this.lblDM.TabIndex = 15;
      this.lblDM.Text = "Domain:";
      // 
      // lblUName
      // 
      this.lblUName.AutoSize = true;
      this.lblUName.Location = new System.Drawing.Point(10, 16);
      this.lblUName.Name = "lblUName";
      this.lblUName.Size = new System.Drawing.Size(61, 13);
      this.lblUName.TabIndex = 16;
      this.lblUName.Text = "Username: ";
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(71, 65);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(198, 20);
      this.txtPassword.TabIndex = 11;
      this.txtPassword.UseSystemPasswordChar = true;
      // 
      // txtDomain
      // 
      this.txtDomain.Location = new System.Drawing.Point(71, 39);
      this.txtDomain.Name = "txtDomain";
      this.txtDomain.Size = new System.Drawing.Size(198, 20);
      this.txtDomain.TabIndex = 12;
      // 
      // txtUserName
      // 
      this.txtUserName.Location = new System.Drawing.Point(71, 13);
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.Size = new System.Drawing.Size(198, 20);
      this.txtUserName.TabIndex = 13;
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(384, 273);
      this.Controls.Add(this.splitContainer1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Auto Logon";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Button btnDecrypt;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.Label lblDomain;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Button btnDeactive;
    private System.Windows.Forms.Button btnSetAutoLogon;
    private System.Windows.Forms.Label lblPW;
    private System.Windows.Forms.Label lblDM;
    private System.Windows.Forms.Label lblUName;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.TextBox txtDomain;
    private System.Windows.Forms.TextBox txtUserName;
    private System.Windows.Forms.Button BtnShowPW;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}

