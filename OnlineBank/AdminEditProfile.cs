using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnlineBank
{
    public partial class AdminEditProfile : Form
    {
        Admin admin = new Admin();
        public AdminEditProfile()
        {
            InitializeComponent();
        }

        private void fName_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = admin.Name;
            textBox4.Text = admin.Email;
            textBox6.Text = admin.Password;
            pictureBox1.Image = admin.Image;
            textBox1.Focus();
            textBox7.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminHomepage adminHomepage = new AdminHomepage();
            adminHomepage.Show();
            this.Hide();
        }

        private void AdminEditProfile_Load(object sender, EventArgs e)
        {
            admin = admin.GetAdmin(LogInPage.aEmail);

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

            textBox1.Text = admin.Name;
            textBox4.Text = admin.Email;
            textBox6.Text = admin.Password;
            pictureBox1.Image = admin.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Visible = false;
                label4.Visible = false;

                if (textBox1.Text != string.Empty && textBox4.Text != string.Empty && textBox6.Text != string.Empty && textBox7.Text != string.Empty)
                {
                    label5.Visible = false;

                    if (textBox6.Text == textBox7.Text)
                    {
                        label6.Visible = false;

                        string tempEmail = admin.Email;
                        admin.Email = textBox4.Text;
                        if (admin.PreviousAccountCheck(admin) == false || admin.Email == tempEmail)
                        {
                            label7.Visible = false;

                            admin.Name = textBox1.Text;
                            admin.Email = textBox4.Text;
                            admin.Password = textBox6.Text;
                            admin.Image = pictureBox1.Image;

                            if (admin.UpdateAdmin(admin))
                            {
                                MessageBox.Show("Update Complete!\nLog in again!");
                                LogInPage logInPage = new LogInPage();
                                logInPage.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Something Wrong!\nTry again!");
                            }
                        }
                        else
                        {
                            admin.Email = tempEmail;
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
    }
}
