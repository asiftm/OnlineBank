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
            /*
            if (textBox1.Text!=string.Empty && textBox2.Text!=string.Empty && textBox3.Text!=string.Empty && textBox3.Text == user.Password)
            {
                string rNum = textBox1.Text;
                string iBal = textBox2.Text;
                if(account.CreateAccount(user, rNum , iBal))
                {
                    UserHomePage userHomePage = new UserHomePage();
                    userHomePage.Show();
                    this.Hide();
                    MessageBox.Show("New account created!");
                }
                {
                    MessageBox.Show("Something went wrong!\nTry again!");
                }
                
            }*/
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("ok");
            //user = user.GetUser(LogInPage.uEmail);
            //bool temp = false;
            //int rNum = 0;
            //while (temp == false)
            //{
            //    Random random = new Random(user.ID);
            //    rNum = random.Next(1000000, 9999999);
            //    temp = account.PreviousAccountNumberCheck(rNum);
            //}
            //textBox1.Text = rNum.ToString();
            //textBox2.Text = "2000.00";
            //Console.WriteLine($"rNum    {rNum}");
        }
    }
}
