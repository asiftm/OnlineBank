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
    public partial class ChangeAccountStatus : Form
    {
        User user = new User();
        Account account = new Account();
        public ChangeAccountStatus()
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
            if(textBox1.Text != string.Empty && textBox2.Text!=string.Empty)
            {
                user.Password = textBox2.Text;
                string accountNumber = textBox1.Text;
                if (user.VerifyUser(user))
                {
                    if (account.EnableStatusCheck(accountNumber))
                    {
                        string newStatus = "0";
                        account.ChangeStatus(accountNumber, newStatus);

                        MessageBox.Show("Account disabled");

                        UserHomePage userHomePage = new UserHomePage();
                        userHomePage.Show();
                        this.Hide();
                    }
                    else if (account.DisableStatusCheck(accountNumber))
                    {
                        string newStatus = "1";
                        account.ChangeStatus(accountNumber, newStatus);
                        MessageBox.Show("Account enabled");
                        UserHomePage userHomePage = new UserHomePage();
                        userHomePage.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong password!");
                }
            }
            else
            {
                MessageBox.Show("Fill all fields");
            }
        }

        private void AccountDelete_Load(object sender, EventArgs e)
        {
            user = user.GetUser(LogInPage.uEmail);
            account.GetAccounts(dataGridView1, user);
        }

        public void AccountDeleteHide()
        {
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
        }
    }
}
