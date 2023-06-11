using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace OnlineBank
{
    public partial class AdminAccessToUserTransaction : Form
    {
        Admin admin = new Admin();
        User user = new User();
        Transaction transaction = new Transaction();

        public AdminAccessToUserTransaction(int userid)
        {
            user.ID = userid;
            InitializeComponent();
        }

        private void AdminAccessToUserTransaction_Load(object sender, EventArgs e)
        {
            label2.Text = $"UserID : {user.ID}";
            dataGridView3.DataSource = transaction.GetOutgoingHistory(user);
            dataGridView4.DataSource = transaction.GetIncomingHistory(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
