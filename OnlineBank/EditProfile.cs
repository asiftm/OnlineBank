using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OnlineBank
{
    public partial class EditProfile : Form
    {
        User user = new User();

        public EditProfile()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty && textBox6.Text != string.Empty && textBox7.Text != string.Empty)
                {
                    if (textBox6.Text == textBox7.Text)
                    {
                        string tempEmail = user.Email;
                        user.Email = textBox4.Text;
                        if (user.PreviousAccountCheck(user) == false || user.Email == tempEmail)
                        {
                            user.FirstName = textBox1.Text;
                            user.LastName = textBox2.Text;
                            user.DateOfBirth = textBox3.Text;
                            user.Address = textBox5.Text;
                            user.Password = textBox6.Text;
                            user.Image = pictureBox1.Image;

                            if (user.UpdateUser(user))
                            {
                                //LogInPage.uEmail = user.Email;
                                MessageBox.Show("Update Complete");
                                UserHomePage userHomePage = new UserHomePage();
                                userHomePage.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Something Wrong!\nTry again!");
                            }
                        }
                        else
                        {
                            user.Email = tempEmail;
                            MessageBox.Show("User email already in use!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Passwords are not same!");
                    }
                }
                else
                {
                    MessageBox.Show("Fill all fields!");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid data format!");
            }
        }

        private void EditProfile_Load(object sender, EventArgs e)
        { 
            user = user.GetUser(LogInPage.uEmail);
            textBox1.Text = user.FirstName;
            textBox2.Text = user.LastName;
            textBox3.Text = user.DateOfBirth;
            textBox4.Text = user.Email;
            textBox5.Text = user.Address;
            textBox6.Text = user.Password;
            pictureBox1.Image = user.Image;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = user.FirstName;
            textBox2.Text = user.LastName;
            textBox3.Text = user.DateOfBirth;
            textBox4.Text = user.Email;
            textBox5.Text = user.Address;
            textBox6.Text = user.Password;
            pictureBox1.Image = user.Image;
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }

            }
            catch
            {
                MessageBox.Show("Try again or try another file!");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
