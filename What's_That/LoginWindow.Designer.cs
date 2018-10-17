namespace What_s_That
{
    partial class LoginWindow
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
            this.loginButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password_TextBox = new System.Windows.Forms.TextBox();
            this.username_TextBox = new System.Windows.Forms.TextBox();
            this.password_linkLabel = new System.Windows.Forms.LinkLabel();
            this.register_linkLabel = new System.Windows.Forms.LinkLabel();
            this.incorrent_login_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.loginButton.Location = new System.Drawing.Point(53, 378);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(124, 74);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 220);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 276);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // password_TextBox
            // 
            this.password_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_TextBox.ForeColor = System.Drawing.SystemColors.Info;
            this.password_TextBox.Location = new System.Drawing.Point(195, 272);
            this.password_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.password_TextBox.Name = "password_TextBox";
            this.password_TextBox.Size = new System.Drawing.Size(304, 34);
            this.password_TextBox.TabIndex = 5;
            this.password_TextBox.TextChanged += new System.EventHandler(this.password_TextBox_TextChanged);
            // 
            // username_TextBox
            // 
            this.username_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.username_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_TextBox.ForeColor = System.Drawing.SystemColors.Info;
            this.username_TextBox.Location = new System.Drawing.Point(195, 217);
            this.username_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.username_TextBox.Name = "username_TextBox";
            this.username_TextBox.Size = new System.Drawing.Size(304, 34);
            this.username_TextBox.TabIndex = 5;
            this.username_TextBox.TextChanged += new System.EventHandler(this.username_TextBox_TextChanged);
            // 
            // password_linkLabel
            // 
            this.password_linkLabel.AutoSize = true;
            this.password_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_linkLabel.Location = new System.Drawing.Point(224, 378);
            this.password_linkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password_linkLabel.Name = "password_linkLabel";
            this.password_linkLabel.Size = new System.Drawing.Size(226, 29);
            this.password_linkLabel.TabIndex = 6;
            this.password_linkLabel.TabStop = true;
            this.password_linkLabel.Text = "Forgot a password?";
            this.password_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.password_linkLabel_LinkClicked);
            // 
            // register_linkLabel
            // 
            this.register_linkLabel.AutoSize = true;
            this.register_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_linkLabel.Location = new System.Drawing.Point(224, 422);
            this.register_linkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.register_linkLabel.Name = "register_linkLabel";
            this.register_linkLabel.Size = new System.Drawing.Size(199, 29);
            this.register_linkLabel.TabIndex = 6;
            this.register_linkLabel.TabStop = true;
            this.register_linkLabel.Text = "Need to register?";
            this.register_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.register_linkLabel_LinkClicked);
            // 
            // incorrent_login_label
            // 
            this.incorrent_login_label.AutoSize = true;
            this.incorrent_login_label.Location = new System.Drawing.Point(191, 326);
            this.incorrent_login_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.incorrent_login_label.Name = "incorrent_login_label";
            this.incorrent_login_label.Size = new System.Drawing.Size(0, 17);
            this.incorrent_login_label.TabIndex = 7;
            this.incorrent_login_label.Click += new System.EventHandler(this.label4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::What_s_That.Properties.Resources.app_logo;
            this.pictureBox1.Location = new System.Drawing.Point(195, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 146);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(127, 454);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // LoginWindow
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(531, 478);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.incorrent_login_label);
            this.Controls.Add(this.register_linkLabel);
            this.Controls.Add(this.password_linkLabel);
            this.Controls.Add(this.username_TextBox);
            this.Controls.Add(this.password_TextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginWindow";
            this.Text = "LoginWindow";
            this.Load += new System.EventHandler(this.LoginWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox password_TextBox;
        private System.Windows.Forms.TextBox username_TextBox;
        private System.Windows.Forms.LinkLabel password_linkLabel;
        private System.Windows.Forms.LinkLabel register_linkLabel;
        private System.Windows.Forms.Label incorrent_login_label;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}