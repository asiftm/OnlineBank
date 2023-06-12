using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnlineBank
{
    public partial class AdminAccessToUserLoans : Form
    {
        Data data = new Data();
        Admin admin = new Admin();
        Account account = new Account();
        User user = new User();
        Loan loan = new Loan();
        public AdminAccessToUserLoans(int userid)
        {
            user.ID = userid;
            InitializeComponent();
        }

        private void AdminAccessToUserLoans_Load(object sender, EventArgs e)
        {
            label7.Text = $"UserID : {user.ID}";
            label5.Visible = false ;

            string currentLoanQuery = $"SELECT loan.id , `Type`, loanAmount as `Loan Amount`, repaymentAmount as `Repayment Amount`, `TotalInstallments(Year)` as `Total Installments(Year)`,`Interest(%)`, AmountPaid as `Amount Paid`, AmountRemaining as `Amount Remaining`, `RemainingInstallments(Year)` as `RemainingInstallments(Year)`,Status,AccountNumber FROM bank.loan join loantypes on loan.loanTypeID = loantypes.id where (`RemainingInstallments(Year)` > 0) and (userID = {user.ID}) and (Status = \"Approved\");";
            dataGridView1.DataSource = data.DataGrid(currentLoanQuery);
            string WaitingLoanQuery = $"SELECT loan.id , `Type`, loanAmount as `Loan Amount`, repaymentAmount as `Repayment Amount`, `TotalInstallments(Year)` as `Total Installments(Year)`,`Interest(%)`, AmountPaid as `Amount Paid`, AmountRemaining as `Amount Remaining`, `RemainingInstallments(Year)` as `RemainingInstallments(Year)`,Status,AccountNumber FROM bank.loan join loantypes on loan.loanTypeID = loantypes.id where (`RemainingInstallments(Year)` > 0) and (userID = {user.ID}) and (Status = \"NotApproved\");";
            dataGridView2.DataSource = data.DataGrid(WaitingLoanQuery);
            string loanHistoryQuery = $"SELECT loan.id , `Type`, loanAmount as `Loan Amount`, repaymentAmount as `Repayment Amount`, `TotalInstallments(Year)` as `Total Installments(Year)`,`Interest(%)`, AmountPaid as `Amount Paid`, AmountRemaining as `Amount Remaining`, `RemainingInstallments(Year)` as `RemainingInstallments(Year)`,Status,AccountNumber FROM bank.loan join loantypes on loan.loanTypeID = loantypes.id where (`RemainingInstallments(Year)` = 0) and (userID = {user.ID}) and (Status = \"Approved\");";
            dataGridView3.DataSource = data.DataGrid(loanHistoryQuery);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminHomepage adminHomepage = new AdminHomepage();
            adminHomepage.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.SelectedCells[0].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !=string.Empty)
            {
                try
                {
                    loan.ID = int.Parse(textBox1.Text);
                    if (loan.CheckNotApprovedLoan(loan))
                    {
                        label5.Visible = false;
                        label5.Text = "Fill the loan id";
                        loan = loan.GetLoanAccount(loan);
                        double balance = account.CheckBalance(loan.AccountNumber);
                        double newBalance = balance + loan.LoanAmount;
                        if (account.EnableStatusCheck(loan.AccountNumber))
                        {
                            if (loan.UpdateLoan(loan) && account.ChangeBalance(loan.AccountNumber, newBalance))
                            {
                                MessageBox.Show("Loan Approved");
                                AdminAccessToUserLoans adminAccessToUserLoans = new AdminAccessToUserLoans(user.ID);
                                adminAccessToUserLoans.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            label5.Visible = true;
                            label5.Text = "Account disabled";
                        }
                    }
                    else
                    {
                        label5.Visible = true;
                        label5.Text = "Already approved";
                    }
                }
                catch
                {
                    label5.Visible = true;
                    label5.Text = "Invalid loan id";
                }
            }
            else
            {
                label5.Text = "Fill the loan id";
                label5.Visible = true ;
            }
        }
    }
}
