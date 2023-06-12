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
        public string Status { get; set; }

        public Loan()
        {
            
        }
        public Loan(int id, int loantypeId, int userId, double loanAmount, double repaymentAmount, int totalInstallments, double amountPaid, double amountRemaining, int remainingInstallments, string status)
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
        }
        public bool CreateLoan(Loan loan)
        {
            bool temp = false;

            string query = $"INSERT INTO `bank`.`loan` (`loanTypeID`, `userID`, `loanAmount`, `repaymentAmount`, `TotalInstallments(Year)`, `AmountPaid`, `AmountRemaining`, `RemainingInstallments(Year)`, `Status`) VALUES ('{loan.LoanTypeID}', '{loan.UserID}', '{loan.LoanAmount}', '{loan.RepaymentAmount}', '{loan.TotalInstallments}', '{loan.AmountPaid}', '{loan.AmountRemaining}', '{loan.RemainingInstallments}', '{loan.Status}');";
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
    }
}
