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
    public partial class AdminHomepage : Form
    {
        Admin admin = new Admin();
        public static string userID;
        public AdminHomepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Hide();
        }

        private void AdminHomepage_Load(object sender, EventArgs e)
        {
            admin = admin.GetAdmin(LogInPage.aEmail);

            label1.Text = admin.Name;
            if (admin.Image != null)
            {
                pictureBox1.Image = admin.Image;
                label5.Visible = false;
            }

            dataGridView1.DataSource = admin.AllUsers();
            label3.Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                label3.Visible = false;
                try
                {
                    int id = Convert.ToInt16(textBox1.Text.Trim());

                    AdminAccessToUserAccounts adminAccessToUserAccounts = new AdminAccessToUserAccounts(id);
                    adminAccessToUserAccounts.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Insert correct id");
                }
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                label3.Visible = false;
                try
                {
                    int id = Convert.ToInt16(textBox1.Text.Trim());

                    AdminAccessToUserTransaction accessToUserTransaction = new AdminAccessToUserTransaction(id);
                    accessToUserTransaction.Show();
                }
                catch
                {
                    MessageBox.Show("Insert correct id");
                }
            }
            else
            {
                label3.Visible = true;
            }
        }
    }
}
