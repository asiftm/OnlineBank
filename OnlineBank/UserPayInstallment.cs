using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnlineBank
{
    public partial class UserPayInstallment : Form
    {
        User user = new User();
        Data data = new Data();
        Account account = new Account();
        Loan loan = new Loan();
        public UserPayInstallment()
        {
            InitializeComponent();
        }

        private void UserPayInstallment_Load(object sender, EventArgs e)
        {
            user = user.GetUser(LogInPage.uEmail);

            dataGridView2.DataSource = account.GetAccounts(user);
            string currentLoanQuery = $"SELECT loan.id,`Type`, repaymentAmount as `Repayment Amount`, `TotalInstallments(Year)` as `Total Installments(Year)`, AmountRemaining as `Amount Remaining`, `RemainingInstallments(Year)` as `RemainingInstallments(Year)` FROM bank.loan join loantypes on loan.loanTypeID = loantypes.id where (`RemainingInstallments(Year)` > 0) and (userID = {user.ID}) and (Status = \"Approved\");";
            dataGridView1.DataSource = data.DataGrid(currentLoanQuery);

            label2.Visible = false;
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView2.SelectedCells[0].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();

            try
            {

                loan.ID = Convert.ToInt32(textBox1.Text);
                if (loan.CheckUserLoan(loan, user))
                {
                    loan = loan.GetRemainingInstallmentLoanAccount(loan);
                    if (loan.CheckRemainingInstallmentLoanAccount(loan, user))
                    {
                        label2.Visible = true;
                        label2.Text = $"You have to pay ${loan.RepaymentAmount / loan.TotalInstallments} per installment. You have to pay {loan.RemainingInstallments} installments.";
                    }
                    else
                    {
                        label2.Visible = false;
                    }
                }
                else
                {

                }
            }
            catch
            {
                label2.Visible = false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                loan.ID = Convert.ToInt32(textBox1.Text);
                if (loan.CheckUserLoan(loan, user))
                {
                    loan = loan.GetRemainingInstallmentLoanAccount(loan);
                    if(loan.CheckRemainingInstallmentLoanAccount(loan,user))
                    {
                        label2.Visible = true;
                        label2.Text = $"You have to pay ${loan.RepaymentAmount / loan.TotalInstallments} per installment. You have to pay {loan.RemainingInstallments} installments.";
                    }
                    else
                    {
                        label2.Visible = false;
                    }
                }
                else
                {
                    label2.Visible = false;
                }
            }
            catch
            {
                label2.Visible = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty && textBox1.Text != string.Empty && textBox1.Text != string.Empty)
            {
                try
                {
                    loan.ID = Convert.ToInt32(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("Wrong User ID!");
                }
                
                if (loan.CheckUserLoan(loan, user))
                {
                    loan = loan.GetRemainingInstallmentLoanAccount(loan);
                    if (loan.CheckRemainingInstallmentLoanAccount(loan, user))
                    {
                        double thisInstallment = loan.RepaymentAmount / loan.TotalInstallments;

                        if (account.VerifyUserAccount(textBox3.Text, user))
                        {
                            if (account.EnableStatusCheck(textBox3.Text))
                            {
                                user.Password = textBox2.Text;
                                if (user.VerifyUser(user))
                                {
                                    double balance = account.CheckBalance(textBox3.Text);
                                    if(thisInstallment<=balance)
                                    {
                                        balance = balance - thisInstallment;
                                        account.ChangeBalance(textBox3.Text, balance);
                                        loan.UpdateAfterInstallment(loan, thisInstallment);

                                        UserPayInstallment userPayInstallment = new UserPayInstallment();
                                        this.Hide();
                                        userPayInstallment.Show();

                                        MessageBox.Show("Payment Complete!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Insufficient Balance!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Wrong Password!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("This account is disabled!");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Wrong Account Number!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Loan ID!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Loan ID!");
                }
            }
            else
            {
                MessageBox.Show("Fill all fields!");
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
    }
}
