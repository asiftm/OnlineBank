using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        Transaction transaction = new Transaction();
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

            if(user.Image != null)
            {
                pictureBox1.Image = user.Image;
                label5.Visible = false;
            }

            if (account.UserAccountCheck(user))
            {
                account.GetAccounts(dataGridView1, user);
                label2.Visible = false;

                transaction.GetOutgoingHistory(dataGridView2, user);
                transaction.GetIncomingHistory(dataGridView3, user);
            }
            else
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                button1.Visible = false;
                button4.Visible = false;
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
            
            SendMoney sendMoney = new SendMoney();
            sendMoney.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeAccountStatus changeAccountStatus = new ChangeAccountStatus();
            changeAccountStatus.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
