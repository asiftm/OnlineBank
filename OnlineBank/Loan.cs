using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBank
{
    public class Loan
    {
        Data data = new Data();
        public int ID { get; set; }//
        public int LoanTypeID { get; set; }//
        public int UserID { get; set; }//
        public double LoanAmount { get; set; }//
        public double RepaymentAmount { get; set; }
        public int TotalInstallments { get; set;}//
        public double AmountPaid { get; set;}//
        public double AmountRemaining { get; set; }//
        public int RemainingInstallments { get; set;}//
        public string Status { get; set; }//
        public string AccountNumber { get; set; }//

        public Loan()
        {
            
        }
        public Loan(int id, int loantypeId, int userId, double loanAmount, double repaymentAmount, int totalInstallments, double amountPaid, double amountRemaining, int remainingInstallments, string status, string accountNumber)
        {
            ID = id;
            LoanTypeID = loantypeId;
            LoanAmount = loanAmount;
            RepaymentAmount = repaymentAmount;
            TotalInstallments = totalInstallments;
            AmountPaid = amountPaid;
            AmountRemaining = amountRemaining;
            RemainingInstallments = remainingInstallments;
            Status = status;
            AccountNumber = accountNumber;
        }
        public bool CreateLoan(Loan loan)
        {
            bool temp = false;

            string query = $"INSERT INTO `bank`.`loan` (`loanTypeID`, `userID`, `loanAmount`, `repaymentAmount`, `TotalInstallments(Year)`, `AmountPaid`, `AmountRemaining`, `RemainingInstallments(Year)`, `Status` , `AccountNumber`) VALUES ('{loan.LoanTypeID}', '{loan.UserID}', '{loan.LoanAmount.ToString().Replace(",",".")}', '{loan.RepaymentAmount.ToString().Replace(",", ".")}', '{loan.TotalInstallments}', '{loan.AmountPaid}', '{loan.AmountRemaining.ToString().Replace(",", ".")}', '{loan.RemainingInstallments}', '{loan.Status}','{loan.AccountNumber}');";
            if(data.NonSelectQuery(query)==1)
            {
                temp=true;
            };
            return temp;
        }
        public bool CheckNotApprovedLoan(Loan loan)
        {
            bool temp = false;
            User user = new User();
            string query = $"select `status` from loan where `Status` like \"NotApproved\" and id = {loan.ID}";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                if (result.HasRows)
                {
                    temp = true;
                }
            }
            return temp;
        }
        public bool UpdateLoan(Loan loan)
        {
            bool temp = false;
            string query = $"UPDATE `bank`.`loan` SET `Status` = 'Approved' WHERE (`id` = '{loan.ID}');";

            if (data.NonSelectQuery(query) == 1)
            {
                temp = true;
            }
            return temp;
        }
        public Loan GetLoanAccount(Loan loan)
        {
            string query = $"select * from `loan` where id='{loan.ID}'";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                loan.ID = Convert.ToInt32(result[0]);
                loan.LoanTypeID = Convert.ToInt32(result[1]);
                loan.UserID = Convert.ToInt32(result[2]);
                loan.LoanAmount = Convert.ToDouble(result[3]);
                loan.RepaymentAmount = Convert.ToDouble(result[4]);
                loan.TotalInstallments = Convert.ToInt32(result[5]);
                loan.AmountPaid = Convert.ToDouble(result[6]);
                loan.AmountRemaining = Convert.ToDouble(result[7]);
                loan.RemainingInstallments = Convert.ToInt32(result[8]);
                loan.Status = result[9].ToString();
                loan.AccountNumber = result[10].ToString();
            }
            return loan;
        }
        public Loan GetRemainingInstallmentLoanAccount(Loan loan)
        {
            string query = $"select * from `loan` where id='{loan.ID}' and `RemainingInstallments(Year)`>0";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                loan.ID = Convert.ToInt32(result[0]);
                loan.LoanTypeID = Convert.ToInt32(result[1]);
                loan.UserID = Convert.ToInt32(result[2]);
                loan.LoanAmount = Convert.ToDouble(result[3]);
                loan.RepaymentAmount = Convert.ToDouble(result[4]);
                loan.TotalInstallments = Convert.ToInt32(result[5]);
                loan.AmountPaid = Convert.ToDouble(result[6]);
                loan.AmountRemaining = Convert.ToDouble(result[7]);
                loan.RemainingInstallments = Convert.ToInt32(result[8]);
                loan.Status = result[9].ToString();
                loan.AccountNumber = result[10].ToString();
            }
            return loan;
        }
        public bool CheckUserLoan(Loan loan,User user)
        {
            bool temp = false;
            string query = $"SELECT * FROM bank.loan where id = {loan.ID} and userID = {user.ID}";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                if (result.HasRows)
                {
                    temp = true;
                }
            }
            return temp;
        }
        public bool CheckRemainingInstallmentLoanAccount(Loan loan,User user)
        {
            bool temp = false;
            string query = $"SELECT * FROM bank.loan where id = {loan.ID} and userID = {user.ID} and `RemainingInstallments(Year)`>0" ;
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                if (result.HasRows)
                {
                    temp = true;
                }
            }
            return temp;
        }
        public bool UpdateAfterInstallment(Loan loan,double thisInstallment)
        {
            bool temp = false;

            string query = $"UPDATE `bank`.`loan` SET `AmountPaid` = '{AmountPaid+thisInstallment.ToString().Replace(",",".")}', `AmountRemaining` = '{(loan.AmountRemaining-thisInstallment).ToString().Replace(",", ".")}', `RemainingInstallments(Year)` = '{loan.RemainingInstallments-1}' WHERE (`id` = '{loan.ID}');";

            if (data.NonSelectQuery(query) == 1)
            {
                temp = true;
            }
            return temp;
        }
    }
}
