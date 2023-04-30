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
    public partial class AccountDelete : Form
    {
        User user = new User();
        public AccountDelete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditProfile editProfile = new EditProfile();
            editProfile.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == user.Password)
            {
                if(user.DeleteUser(user))
                {
                    
                }
            }
            else
            {
                MessageBox.Show("Wrong password!");
            }
        }

        private void AccountDelete_Load(object sender, EventArgs e)
        {
            user = user.GetUser(LogInPage.uEmail);
        }

        public void AccountDeleteHide()
        {
            this.Hide();
        }
    }
}
