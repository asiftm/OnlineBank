namespace OnlineBank
{
    partial class UserHomePage
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
            this.userProfilePicture = new System.Windows.Forms.PictureBox();
            this.userName = new System.Windows.Forms.Label();
            this.logout = new System.Windows.Forms.Button();
            this.createAccount = new System.Windows.Forms.Button();
            this.editProfile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // userProfilePicture
            // 
            this.userProfilePicture.Location = new System.Drawing.Point(12, 12);
            this.userProfilePicture.Name = "userProfilePicture";
            this.userProfilePicture.Size = new System.Drawing.Size(50, 50);
            this.userProfilePicture.TabIndex = 0;
            this.userProfilePicture.TabStop = false;
            this.userProfilePicture.Click += new System.EventHandler(this.userProfilePicture_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(81, 12);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(77, 18);
            this.userName.TabIndex = 1;
            this.userName.Text = "Username";
            this.userName.Click += new System.EventHandler(this.label1_Click);
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.OrangeRed;
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.Location = new System.Drawing.Point(713, 12);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 23);
            this.logout.TabIndex = 2;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // createAccount
            // 
            this.createAccount.BackColor = System.Drawing.Color.ForestGreen;
            this.createAccount.ForeColor = System.Drawing.Color.White;
            this.createAccount.Location = new System.Drawing.Point(475, 12);
            this.createAccount.Name = "createAccount";
            this.createAccount.Size = new System.Drawing.Size(117, 32);
            this.createAccount.TabIndex = 3;
            this.createAccount.Text = "Create new account";
            this.createAccount.UseVisualStyleBackColor = false;
            this.createAccount.Click += new System.EventHandler(this.createAccount_Click);
            // 
            // editProfile
            // 
            this.editProfile.BackColor = System.Drawing.Color.ForestGreen;
            this.editProfile.ForeColor = System.Drawing.Color.White;
            this.editProfile.Location = new System.Drawing.Point(363, 11);
            this.editProfile.Name = "editProfile";
            this.editProfile.Size = new System.Drawing.Size(86, 33);
            this.editProfile.TabIndex = 4;
            this.editProfile.Text = "Edit Profile";
            this.editProfile.UseVisualStyleBackColor = false;
            this.editProfile.Click += new System.EventHandler(this.editProfile_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(363, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send Money";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.editProfile);
            this.Controls.Add(this.createAccount);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.userProfilePicture);
            this.Name = "UserHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserHomePage";
            this.Load += new System.EventHandler(this.UserHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox userProfilePicture;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button createAccount;
        private System.Windows.Forms.Button editProfile;
        private System.Windows.Forms.Button button1;
    }
}