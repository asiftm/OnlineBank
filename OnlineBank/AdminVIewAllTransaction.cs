﻿using System;
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
    public partial class AdminVIewAllTransaction : Form
    {
        Data data = new Data();
        public AdminVIewAllTransaction()
        {
            InitializeComponent();
        }

        private void AdminVIewAllTransaction_Load(object sender, EventArgs e)
        {
            string query = $"SELECT id as `TransactionID`, sender as Sender, receiver as Receiver,amount as Amount FROM transaction";
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
