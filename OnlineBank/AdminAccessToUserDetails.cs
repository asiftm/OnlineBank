using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBank
{
    public partial class AdminAccessToUserDetails : Form
    {
        Admin admin = new Admin();
        User user = new User();
        public AdminAccessToUserDetails(int userid)
        {
            user.ID = userid;
            InitializeComponent();
        }

        private void AdminAccessToUserDetails_Load(object sender, EventArgs e)
        {
            label2.Text = $"UserID : {user.ID}";
            label3.Visible = false ;
            label4.Visible = false ;
            label5.Visible = false ;
            label6.Visible = false ;
            label7.Visible = false ;

            user = user.GetUserByID(user.ID);
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

        private void button3_Click(object sender, EventArgs e)
        {
            AdminHomepage adminHomepage = new AdminHomepage();
            adminHomepage.Show();
            this.Hide();
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
            textBox7.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Visible = false;
                label4.Visible = false;

                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty && textBox6.Text != string.Empty && textBox7.Text != string.Empty)
                {
                    label5.Visible = false;

                    if (textBox6.Text == textBox7.Text)
                    {
                        label6.Visible = false;

                        string tempEmail = user.Email;
                        user.Email = textBox4.Text;
                        if (user.PreviousAccountCheck(user) == false || user.Email == tempEmail)
                        {
                            label7.Visible = false;
                            
                            user.FirstName = textBox1.Text;
                            user.LastName = textBox2.Text;
                            user.DateOfBirth = textBox3.Text;
                            user.Address = textBox5.Text;
                            user.Password = textBox6.Text;
                            user.Image = pictureBox1.Image;

                            if (user.UpdateUser(user))
                            {
                                MessageBox.Show("Update Complete");
                                AdminHomepage adminHomepage = new AdminHomepage();
                                adminHomepage.Show();
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
                            label7.Visible = true;
                        }
                    }
                    else
                    {
                        label6.Visible = true;
                    }
                }
                else
                {

                    label5.Visible = true;
                }
            }
            catch (Exception)
            {
                label3.Visible = true;
                label4.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            user.Image = pictureBox1.Image;
        }
    }
}
