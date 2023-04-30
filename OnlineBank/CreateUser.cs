using MySqlConnector;
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
    public partial class CreateUser : Form
    {
        User user = new User();
        public CreateUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=string.Empty && textBox2.Text!=string.Empty && textBox3.Text!=string.Empty && textBox4.Text!=string.Empty && textBox5.Text!=string.Empty && textBox6.Text!=string.Empty)
            {
                if (textBox7.Text == textBox5.Text)
                {
                    user.FirstName = textBox1.Text;
                    user.LastName = textBox2.Text;
                    user.Password = textBox5.Text;
                    user.DateOfBirth = DateTime.ParseExact(textBox3.Text,"yyyy-mm-dd",null);
                    user.Email = textBox4.Text;
                    user.Address = textBox6.Text;

                    if (user.PreviousAccountCheck(user) == false)
                    {
                        if (user.CreateUser(user))
                        {
                            MessageBox.Show("User Created");
                        }
                        else
                        {
                            MessageBox.Show("Something Wrong!\nTry again!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User email already in use!");
                    }
                }
                else
                {
                    MessageBox.Show("Password does not matched!");
                }
            }
            else
            {
                MessageBox.Show("Fill all fields!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox1.Focus();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lName_Click(object sender, EventArgs e)
        {

        }

        private void dob_Click(object sender, EventArgs e)
        {

        }

        private void address_Click(object sender, EventArgs e)
        {

        }

        private void cPassword_Click(object sender, EventArgs e)
        {

        }

        private void email_Click(object sender, EventArgs e)
        {

        }

        private void fName_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
