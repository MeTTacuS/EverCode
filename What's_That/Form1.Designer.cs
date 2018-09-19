namespace What_s_That
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.buttonIdentify = new System.Windows.Forms.Button();
            this.buttonPicture = new System.Windows.Forms.Button();
            this.buttonAddFace = new System.Windows.Forms.Button();
            this.imgCamUser = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonIdentify
            // 
            this.buttonIdentify.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttonIdentify.AutoSize = true;
            this.buttonIdentify.Location = new System.Drawing.Point(65, 69);
            this.buttonIdentify.Name = "buttonIdentify";
            this.buttonIdentify.Size = new System.Drawing.Size(96, 39);
            this.buttonIdentify.TabIndex = 0;
            this.buttonIdentify.Text = "Identify Face";
            this.buttonIdentify.UseVisualStyleBackColor = true;
            this.buttonIdentify.Click += new System.EventHandler(this.buttonIdentify_Click);
            // 
            // buttonPicture
            // 
            this.buttonPicture.Location = new System.Drawing.Point(65, 114);
            this.buttonPicture.Name = "buttonPicture";
            this.buttonPicture.Size = new System.Drawing.Size(96, 39);
            this.buttonPicture.TabIndex = 1;
            this.buttonPicture.Text = "Identify Picture";
            this.buttonPicture.UseVisualStyleBackColor = true;
            // 
            // buttonAddFace
            // 
            this.buttonAddFace.Location = new System.Drawing.Point(65, 159);
            this.buttonAddFace.Name = "buttonAddFace";
            this.buttonAddFace.Size = new System.Drawing.Size(96, 39);
            this.buttonAddFace.TabIndex = 2;
            this.buttonAddFace.Text = "Add Face";
            this.buttonAddFace.UseVisualStyleBackColor = true;
            // 
            // imgCamUser
            // 
            this.imgCamUser.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.imgCamUser.Location = new System.Drawing.Point(213, 12);
            this.imgCamUser.Name = "imgCamUser";
            this.imgCamUser.Size = new System.Drawing.Size(336, 248);
            this.imgCamUser.TabIndex = 2;
            this.imgCamUser.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(561, 311);
            this.Controls.Add(this.imgCamUser);
            this.Controls.Add(this.buttonAddFace);
            this.Controls.Add(this.buttonPicture);
            this.Controls.Add(this.buttonIdentify);
            this.Name = "MainWindow";
            this.Text = "What\'s That?";
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonIdentify;
        private System.Windows.Forms.Button buttonPicture;
        private System.Windows.Forms.Button buttonAddFace;
        private Emgu.CV.UI.ImageBox imgCamUser;
    }
}

