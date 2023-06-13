using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBank
{
    public partial class UserTakeLoan : Form
    {
        User user = new User();
        Data data = new Data();
        Account account = new Account();
        Loan loan = new Loan();
        LoanType loanTypes = new LoanType();

        public UserTakeLoan()
        {
            InitializeComponent();
        }

        private void UserTakeLoan_Load(object sender, EventArgs e)
        {
            user = user.GetUser(LogInPage.uEmail);

            string loanTypeQuery = $"SELECT * FROM bank.loantypes;";
            dataGridView1.DataSource = data.DataGrid(loanTypeQuery);
            dataGridView2.DataSource = account.GetAccounts(user);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserLoans userLoans = new UserLoans();
            userLoans.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox1.Focus();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.SelectedCells[0].Value.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox6.Text != string.Empty)
            {
                int typeId = Convert.ToInt16(textBox1.Text);

                loanTypes = loanTypes.GetLoanType(typeId);
                if (loanTypes.ID > 0)
                {
                    user.Password = textBox6.Text;
                    if (user.VerifyUser(user))
                    {
                        loan.LoanAmount = Convert.ToInt32(textBox2.Text);
                        loan.TotalInstallments = Convert.ToInt32(textBox3.Text);

                        if (loan.LoanAmount <= 50000)
                        {
                            if (loan.TotalInstallments <= 20)
                            {
                                loan.LoanTypeID = loanTypes.ID;
                                loan.UserID = user.ID;
                                loan.AmountPaid = 0;

                                double a = loan.LoanAmount;
                                double b = loanTypes.Interest;
                                double c = loan.TotalInstallments;
                                loan.RepaymentAmount = (a + ( a* ( b/ 100) *c ));

                                loan.AmountRemaining = loan.RepaymentAmount;
                                loan.RemainingInstallments = loan.TotalInstallments;
                                loan.Status = "NotApproved";

                                textBox5.Text = loan.RepaymentAmount.ToString();
                                string receiveAccount = textBox4.Text;
                                loan.AccountNumber = receiveAccount;
                                if (account.VerifyUserAccount(receiveAccount, user) && account.EnableStatusCheck(receiveAccount))
                                {
                                    if (loan.CreateLoan(loan))
                                    {
                                        MessageBox.Show("Loan request is sent for approve.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Your account is disabled or wrong accoount number");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Maximum Installment(year) is 20!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Maximum Loan Amount is 50000!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid loan number!");
                }
            }
            else
            {
                MessageBox.Show("Fill all the fields!");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty)
            {
                int typeId = Convert.ToInt16(textBox1.Text);

                loanTypes = loanTypes.GetLoanType(typeId);
                if (loanTypes.ID > 0)
                {
                    loan.LoanAmount = Convert.ToInt32(textBox2.Text);
                    loan.TotalInstallments = Convert.ToInt32(textBox3.Text);

                    if (loan.LoanAmount <= 50000)
                    {
                        if (loan.TotalInstallments <= 20)
                        {
                            double a = loan.LoanAmount;
                            double b = loanTypes.Interest;
                            double c = loan.TotalInstallments;
                            loan.RepaymentAmount = (a + (a * (b / 100) * c));
                            textBox5.Text = loan.RepaymentAmount.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Maximum Installment(year) is 20!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Maximum Loan Amount is 50000!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid loan number!");
                }
            }
            else
            {
                MessageBox.Show("Fill all the fields!");
            }
        }
    }
}
