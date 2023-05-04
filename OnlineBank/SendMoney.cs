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
    public partial class SendMoney : Form
    {
        User user = new User();
        Account account = new Account();

        public SendMoney()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
            this.Hide();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void SendMoney_Load(object sender, EventArgs e)
        {
            user = user.GetUser(LogInPage.uEmail);
            account.GetAccount(dataGridView1, user);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox4.Text != string.Empty)
            {
                string senderAccount = textBox1.Text;
                string receiverAccount = textBox2.Text;
                double moneyInput = Convert.ToDouble(textBox4.Text.ToString());

                if (account.VerifyAccount(senderAccount) && account.VerifyAccount(receiverAccount))
                {
                    double senderBalance = account.CheckBalance(senderAccount);
                    double receiverBalance = account.CheckBalance(receiverAccount);
                    if (senderBalance >= moneyInput)
                    {
                        user.Password = textBox3.Text;
                        if(user.VerifyUser(user))
                        {
                            senderBalance = senderBalance - moneyInput;
                            receiverBalance = receiverBalance + moneyInput;

                            account.ChangeBalance(senderAccount, senderBalance);
                            account.ChangeBalance(receiverAccount, receiverBalance);

                            MessageBox.Show("Transection Successful");

                            UserHomePage userHomePage = new UserHomePage();
                            userHomePage.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Wrong Password");
                            textBox3.Focus();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Insufficient Balance!");
                        textBox4.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Account Number!");
                    textBox2.Focus();
                }
            }
            else
            {
                MessageBox.Show("Fill all fields!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
