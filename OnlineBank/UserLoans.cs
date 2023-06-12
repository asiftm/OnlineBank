using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OnlineBank
{
    public partial class UserLoans : Form
    {
        User user = new User();
        Data data = new Data();
        public UserLoans()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
            this.Hide();
        }

        private void UserLoans_Load(object sender, EventArgs e)
        {
            user = user.GetUser(LogInPage.uEmail);

            string currentLoanQuery = $"SELECT `Type`, loanAmount as `Loan Amount`, repaymentAmount as `Repayment Amount`, `TotalInstallments(Year)` as `Total Installments(Year)`,`Interest(%)`, AmountPaid as `Amount Paid`, AmountRemaining as `Amount Remaining`, `RemainingInstallments(Year)` as `RemainingInstallments(Year)`  FROM bank.loan join loantypes on loan.loanTypeID = loantypes.id where (`RemainingInstallments(Year)` > 0) and (userID = {user.ID}) and (Status = \"Approved\");";
            dataGridView1.DataSource = data.DataGrid(currentLoanQuery);
            string WaitingLoanQuery = $"SELECT `Type`, loanAmount as `Loan Amount`, repaymentAmount as `Repayment Amount`, `TotalInstallments(Year)` as `Total Installments(Year)`,`Interest(%)`, AmountPaid as `Amount Paid`, AmountRemaining as `Amount Remaining`, `RemainingInstallments(Year)` as `RemainingInstallments(Year)`  FROM bank.loan join loantypes on loan.loanTypeID = loantypes.id where (`RemainingInstallments(Year)` > 0) and (userID = {user.ID}) and (Status = \"NotApproved\");";
            dataGridView2.DataSource = data.DataGrid(WaitingLoanQuery);
            string loanHistoryQuery = $"SELECT `Type`, loanAmount as `Loan Amount`, repaymentAmount as `Repayment Amount`, `TotalInstallments(Year)` as `Total Installments(Year)`,`Interest(%)`, AmountPaid as `Amount Paid`, AmountRemaining as `Amount Remaining`, `RemainingInstallments(Year)` as `RemainingInstallments(Year)`  FROM bank.loan join loantypes on loan.loanTypeID = loantypes.id where (`RemainingInstallments(Year)` = 0) and (userID = {user.ID}) and (Status = \"Approved\");";
            dataGridView3.DataSource = data.DataGrid(loanHistoryQuery);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserTakeLoan userTakeLoan = new UserTakeLoan();
            userTakeLoan.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
