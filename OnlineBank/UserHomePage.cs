using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBank
{
    public partial class UserHomePage : Form
    {
        User user = new User();
        
        
        public UserHomePage()
        {
            InitializeComponent();
        }

        private void userProfilePicture_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void logout_Click(object sender, EventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Hide();
        }

        private void editProfile_Click(object sender, EventArgs e)
        {
            EditProfile editProfile = new EditProfile();
            editProfile.Show();
            this.Hide();

        }

        private void UserHomePage_Load(object sender, EventArgs e)
        {
            user = user.GetUser(LogInPage.uEmail);
            userName.Text = user.FirstName + " " + user.LastName;
        }
    }
}
