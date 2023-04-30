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
    public partial class AddAccount : Form
    {
        User user = new User();
        Account account = new Account();

        public AddAccount()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text!=string.Empty && textBox2.Text!=string.Empty && textBox3.Text!=string.Empty)
            {
                if(textBox3.Text == user.Password)
                {
                    string rNum = textBox1.Text;
                    string iBal = textBox2.Text;
                    if (account.CreateAccount(user, rNum, iBal))
                    {
                        UserHomePage userHomePage = new UserHomePage();
                        userHomePage.Show();
                        this.Hide();
                        MessageBox.Show("New account created!");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong!\nTry again!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }
            }
            else
            {
                MessageBox.Show("Fill all fields");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            user = user.GetUser(LogInPage.uEmail);
            int randomNumber = account.GenerateAccountNumber(user);
            textBox1.Text = randomNumber.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
            this.Hide();
        }
    }
}
