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
    public partial class AdminVIewAllUsers : Form
    {
        Data data = new Data();
        public AdminVIewAllUsers()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminVIewAllAccounts_Load(object sender, EventArgs e)
        {
            string query = $"SELECT id as UserID,FirstName,LastName,`Password`,DateOfBirth,Email,Address FROM bank.user;";
            dataGridView1.DataSource = data.DataGrid(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
