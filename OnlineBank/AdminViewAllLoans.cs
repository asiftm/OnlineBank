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
    public partial class AdminViewAllLoans : Form
    {
        Data data = new Data();
        public AdminViewAllLoans()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminHomepage adminHomepage = new AdminHomepage();
            adminHomepage.Show();
            this.Hide();
        }

        private void AdminViewAllLoans_Load(object sender, EventArgs e)
        {
            string query = $"SELECT loan.id,Status,user.Email,loantypes.Type,`Interest(%)`,loanAmount,repaymentAmount,`TotalInstallments(Year)`,AmountPaid,AmountRemaining,`RemainingInstallments(Year)` FROM bank.loan join loantypes on loan.loanTypeID = loantypes.ID join user on user.ID = loan.userID";
            dataGridView1.DataSource = data.DataGrid(query);
        }
    }
}
