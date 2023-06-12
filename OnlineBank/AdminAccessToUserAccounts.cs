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
    public partial class AdminAccessToUserAccounts : Form
    {
        Admin admin = new Admin();
        Account account = new Account();
        User user = new User();
        public AdminAccessToUserAccounts(int userid)
        {
            user.ID = userid;
            InitializeComponent();
        }

        private void AdminAccessToUserAccounts_Load(object sender, EventArgs e)
        {
            label2.Text = $"UserID : {user.ID}";
            label3.Visible = false;
            label5.Text = admin.Count($"select count(*) from accounts where UserID = {user.ID}");
            dataGridView1.DataSource = account.GetAccounts(user);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminHomepage adminHomepage = new AdminHomepage();
            adminHomepage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty )
            {
                string accountNumber = textBox1.Text;

                if (account.EnableStatusCheck(accountNumber))
                {
                    string newStatus = "0";
                    account.ChangeStatus(accountNumber, newStatus);

                    MessageBox.Show("Account disabled");
                }
                else if (account.DisableStatusCheck(accountNumber))
                {
                    string newStatus = "1";
                    account.ChangeStatus(accountNumber, newStatus);
                    MessageBox.Show("Account enabled");
                }
                dataGridView1.DataSource = account.GetAccounts(user);
            }
            else
            {
                label3.Visible = true;
            }
        }
    }
}
