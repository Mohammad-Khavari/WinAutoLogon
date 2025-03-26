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
      this.picInactive = new System.Windows.Forms.PictureBox();
      this.picActive = new System.Windows.Forms.PictureBox();
      this.btnDecrypt = new System.Windows.Forms.Button();
      this.lblPassword = new System.Windows.Forms.Label();
      this.lblDomain = new System.Windows.Forms.Label();
      this.lblUsername = new System.Windows.Forms.Label();
      this.BtnShowPW = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.btnExit = new System.Windows.Forms.Button();
      this.btnDeactive = new System.Windows.Forms.Button();
      this.btnSetAutoLogon = new System.Windows.Forms.Button();
      this.lblPW = new System.Windows.Forms.Label();
      this.lblDM = new System.Windows.Forms.Label();
      this.lblUName = new System.Windows.Forms.Label();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.txtDomain = new System.Windows.Forms.TextBox();
      this.txtUserName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picInactive)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picActive)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.picInactive);
      this.splitContainer1.Panel1.Controls.Add(this.picActive);
      this.splitContainer1.Panel1.Controls.Add(this.btnDecrypt);
      this.splitContainer1.Panel1.Controls.Add(this.lblPassword);
      this.splitContainer1.Panel1.Controls.Add(this.lblDomain);
      this.splitContainer1.Panel1.Controls.Add(this.lblUsername);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.splitContainer1.Panel2.Controls.Add(this.BtnShowPW);
      this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
      this.splitContainer1.Panel2.Controls.Add(this.btnExit);
      this.splitContainer1.Panel2.Controls.Add(this.btnDeactive);
      this.splitContainer1.Panel2.Controls.Add(this.btnSetAutoLogon);
      this.splitContainer1.Panel2.Controls.Add(this.lblPW);
      this.splitContainer1.Panel2.Controls.Add(this.lblDM);
      this.splitContainer1.Panel2.Controls.Add(this.lblUName);
      this.splitContainer1.Panel2.Controls.Add(this.txtPassword);
      this.splitContainer1.Panel2.Controls.Add(this.txtDomain);
      this.splitContainer1.Panel2.Controls.Add(this.txtUserName);
      this.splitContainer1.Panel2.Controls.Add(this.label1);
      this.splitContainer1.Size = new System.Drawing.Size(384, 273);
      this.splitContainer1.SplitterDistance = 109;
      this.splitContainer1.SplitterWidth = 1;
      this.splitContainer1.TabIndex = 0;
      // 
      // picInactive
      // 
      this.picInactive.Image = global::Auto_Logon.Properties.Resources.inactive;
      this.picInactive.Location = new System.Drawing.Point(280, 3);
      this.picInactive.Name = "picInactive";
      this.picInactive.Size = new System.Drawing.Size(104, 102);
      this.picInactive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picInactive.TabIndex = 20;
      this.picInactive.TabStop = false;
      this.picInactive.Visible = false;
      // 
      // picActive
      // 
      this.picActive.Image = global::Auto_Logon.Properties.Resources.Active;
      this.picActive.Location = new System.Drawing.Point(288, 3);
      this.picActive.Name = "picActive";
      this.picActive.Size = new System.Drawing.Size(93, 103);
      this.picActive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picActive.TabIndex = 20;
      this.picActive.TabStop = false;
      this.picActive.Visible = false;
      // 
      // btnDecrypt
      // 
      this.btnDecrypt.Location = new System.Drawing.Point(10, 82);
      this.btnDecrypt.Name = "btnDecrypt";
      this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
      this.btnDecrypt.TabIndex = 0;
      this.btnDecrypt.Text = "Check";
      this.btnDecrypt.UseVisualStyleBackColor = true;
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Location = new System.Drawing.Point(10, 56);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(56, 13);
      this.lblPassword.TabIndex = 10;
      this.lblPassword.Text = "Password:";
      // 
      // lblDomain
      // 
      this.lblDomain.AutoSize = true;
      this.lblDomain.Location = new System.Drawing.Point(10, 34);
      this.lblDomain.Name = "lblDomain";
      this.lblDomain.Size = new System.Drawing.Size(46, 13);
      this.lblDomain.TabIndex = 9;
      this.lblDomain.Text = "Domain:";
      // 
      // lblUsername
      // 
      this.lblUsername.AutoSize = true;
      this.lblUsername.Location = new System.Drawing.Point(10, 12);
      this.lblUsername.Name = "lblUsername";
      this.lblUsername.Size = new System.Drawing.Size(58, 13);
      this.lblUsername.TabIndex = 8;
      this.lblUsername.Text = "Username:";
      // 
      // BtnShowPW
      // 
      this.BtnShowPW.BackColor = System.Drawing.Color.LemonChiffon;
      this.BtnShowPW.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnShowPW.Location = new System.Drawing.Point(243, 74);
      this.BtnShowPW.Margin = new System.Windows.Forms.Padding(0);
      this.BtnShowPW.Name = "BtnShowPW";
      this.BtnShowPW.Size = new System.Drawing.Size(28, 24);
      this.BtnShowPW.TabIndex = 3;
      this.BtnShowPW.UseVisualStyleBackColor = false;
      this.BtnShowPW.Click += new System.EventHandler(this.BtnShowPW_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::Auto_Logon.Properties.Resources.lock_clean;
      this.pictureBox1.Location = new System.Drawing.Point(287, 7);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(106, 88);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 12;
      this.pictureBox1.TabStop = false;
      // 
      // btnExit
      // 
      this.btnExit.Location = new System.Drawing.Point(229, 133);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(75, 23);
      this.btnExit.TabIndex = 6;
      this.btnExit.Text = "Exit";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // btnDeactive
      // 
      this.btnDeactive.Enabled = false;
      this.btnDeactive.Location = new System.Drawing.Point(148, 133);
      this.btnDeactive.Name = "btnDeactive";
      this.btnDeactive.Size = new System.Drawing.Size(75, 23);
      this.btnDeactive.TabIndex = 5;
      this.btnDeactive.Text = "Deactivate";
      this.btnDeactive.UseVisualStyleBackColor = true;
      this.btnDeactive.Click += new System.EventHandler(this.btnDeactive_Click_1);
      // 
      // btnSetAutoLogon
      // 
      this.btnSetAutoLogon.Location = new System.Drawing.Point(67, 133);
      this.btnSetAutoLogon.Name = "btnSetAutoLogon";
      this.btnSetAutoLogon.Size = new System.Drawing.Size(75, 23);
      this.btnSetAutoLogon.TabIndex = 4;
      this.btnSetAutoLogon.Text = "Activate";
      this.btnSetAutoLogon.UseVisualStyleBackColor = true;
      // 
      // lblPW
      // 
      this.lblPW.AutoSize = true;
      this.lblPW.Location = new System.Drawing.Point(8, 78);
      this.lblPW.Name = "lblPW";
      this.lblPW.Size = new System.Drawing.Size(56, 13);
      this.lblPW.TabIndex = 14;
      this.lblPW.Text = "Password:";
      // 
      // lblDM
      // 
      this.lblDM.AutoSize = true;
      this.lblDM.Location = new System.Drawing.Point(8, 52);
      this.lblDM.Name = "lblDM";
      this.lblDM.Size = new System.Drawing.Size(46, 13);
      this.lblDM.TabIndex = 15;
      this.lblDM.Text = "Domain:";
      // 
      // lblUName
      // 
      this.lblUName.AutoSize = true;
      this.lblUName.Location = new System.Drawing.Point(8, 26);
      this.lblUName.Name = "lblUName";
      this.lblUName.Size = new System.Drawing.Size(61, 13);
      this.lblUName.TabIndex = 16;
      this.lblUName.Text = "Username: ";
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(69, 75);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(174, 20);
      this.txtPassword.TabIndex = 2;
      this.txtPassword.UseSystemPasswordChar = true;
      // 
      // txtDomain
      // 
      this.txtDomain.Location = new System.Drawing.Point(69, 49);
      this.txtDomain.Name = "txtDomain";
      this.txtDomain.Size = new System.Drawing.Size(174, 20);
      this.txtDomain.TabIndex = 1;
      // 
      // txtUserName
      // 
      this.txtUserName.Location = new System.Drawing.Point(69, 23);
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.Size = new System.Drawing.Size(174, 20);
      this.txtUserName.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
      this.label1.Location = new System.Drawing.Point(310, 143);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 18);
      this.label1.TabIndex = 17;
      this.label1.Text = "MK® 2025";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
      this.Load += new System.EventHandler(this.FrmMain_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picInactive)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picActive)).EndInit();
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
    private System.Windows.Forms.PictureBox picActive;
    private System.Windows.Forms.PictureBox picInactive;
    private System.Windows.Forms.Label label1;
  }
}

