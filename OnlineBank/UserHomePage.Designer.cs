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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // userProfilePicture
            // 
            this.userProfilePicture.Location = new System.Drawing.Point(16, 15);
            this.userProfilePicture.Margin = new System.Windows.Forms.Padding(4);
            this.userProfilePicture.Name = "userProfilePicture";
            this.userProfilePicture.Size = new System.Drawing.Size(67, 62);
            this.userProfilePicture.TabIndex = 0;
            this.userProfilePicture.TabStop = false;
            this.userProfilePicture.Click += new System.EventHandler(this.userProfilePicture_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(108, 15);
            this.userName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(124, 29);
            this.userName.TabIndex = 1;
            this.userName.Text = "Username";
            this.userName.Click += new System.EventHandler(this.label1_Click);
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.OrangeRed;
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.Location = new System.Drawing.Point(800, 21);
            this.logout.Margin = new System.Windows.Forms.Padding(4);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(100, 28);
            this.logout.TabIndex = 2;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // createAccount
            // 
            this.createAccount.BackColor = System.Drawing.Color.ForestGreen;
            this.createAccount.ForeColor = System.Drawing.Color.White;
            this.createAccount.Location = new System.Drawing.Point(564, 16);
            this.createAccount.Margin = new System.Windows.Forms.Padding(4);
            this.createAccount.Name = "createAccount";
            this.createAccount.Size = new System.Drawing.Size(156, 39);
            this.createAccount.TabIndex = 3;
            this.createAccount.Text = "Create new account";
            this.createAccount.UseVisualStyleBackColor = false;
            this.createAccount.Click += new System.EventHandler(this.createAccount_Click);
            // 
            // editProfile
            // 
            this.editProfile.BackColor = System.Drawing.Color.ForestGreen;
            this.editProfile.ForeColor = System.Drawing.Color.White;
            this.editProfile.Location = new System.Drawing.Point(411, 15);
            this.editProfile.Margin = new System.Windows.Forms.Padding(4);
            this.editProfile.Name = "editProfile";
            this.editProfile.Size = new System.Drawing.Size(115, 41);
            this.editProfile.TabIndex = 4;
            this.editProfile.Text = "Edit Profile";
            this.editProfile.UseVisualStyleBackColor = false;
            this.editProfile.Click += new System.EventHandler(this.editProfile_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(411, 153);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send Money";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 153);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 33;
            this.dataGridView1.Size = new System.Drawing.Size(367, 238);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Account Details:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Chocolate;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(20, 454);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(177, 28);
            this.button4.TabIndex = 37;
            this.button4.Text = "Change Account Status";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "You have no accounts to show";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // UserHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(913, 495);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.editProfile);
            this.Controls.Add(this.createAccount);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.userProfilePicture);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserHomePage";
            this.Load += new System.EventHandler(this.UserHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
    }
}