using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBank
{
    public partial class UserHomePage : Form
    {
        User user = new User();
        Account account = new Account();
        bool moneySend = false;

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

            if (account.UserAccountCheck(user))
            {
                moneySend = true;
                account.GetAccount(dataGridView1, user);
            }
            else
            {
                dataGridView1.Visible = false;;
                
            }
        }

        private void createAccount_Click(object sender, EventArgs e)
        {
            AddAccount addAccount = new AddAccount();
            addAccount.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (moneySend)
            {
                SendMoney sendMoney = new SendMoney();
                sendMoney.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Create account to send money!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AccountDisable account = new AccountDisable();
            account.Show();
            this.Hide();
        }
    }
}
