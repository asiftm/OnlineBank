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
    public partial class AdminVIewAllAccounts : Form
    {
        Data data = new Data();
        public AdminVIewAllAccounts()
        {
            InitializeComponent();
        }

        private void AdminVIewAllAccounts_Load(object sender, EventArgs e)
        {
            string query = $"SELECT AccountNumber,Balance,Status,email as Email,UserID FROM user JOIN accounts ON user.ID = accounts.UserID";
            dataGridView1.DataSource = data.DataGrid(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminHomepage adminHomepage = new AdminHomepage();
            adminHomepage.Show();
            this.Hide();
        }
    }
}
