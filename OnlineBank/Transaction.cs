using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBank
{
    internal class Transaction
    {
        Data data = new Data();

        //properties
        public int ID { get; set; }
        public int SenderAccount { get; set; }
        public int ReceiverAccount { get; set; }
        public decimal Amount { get; set; }

        //constructor
        public Transaction()
        {
            
        }
        public Transaction(int senderAccount, int receiverAccount)
        {
            SenderAccount = senderAccount;
            ReceiverAccount = receiverAccount;
        }public Transaction(int id, int senderAccount, int receiverAccount)
        {
            ID = id;
            SenderAccount = senderAccount;
            ReceiverAccount = receiverAccount;
        }

        //method
        public bool AddTransactionHistory(string senderAccount,string receiverAccount, double amount)
        {
            bool temp = false;
            string query = $"INSERT INTO `transaction` (`id`, `sender`, `receiver`, `amount`) VALUES (NULL, '{senderAccount}', '{receiverAccount}', '{amount}');";
            if (data.NonSelectQuery(query) == 1)
            {
                temp = true;
            }
            return temp;
        }
        public DataTable GetOutgoingHistory(User user)
        {
            string query = $"SELECT receiver as 'Sent to' ,amount as 'Amount' FROM user JOIN accounts ON user.ID = accounts.UserID JOIN transaction ON accounts.AccountNumber = transaction.sender WHERE UserID = {user.ID};";
            return data.DataGrid(query);
        }public DataTable GetIncomingHistory(User user)
        {
            string query = $"SELECT sender as 'Received from',amount as 'Amount' FROM user JOIN accounts ON user.ID = accounts.UserID JOIN transaction ON accounts.AccountNumber = transaction.receiver WHERE UserID = {user.ID};";
            return data.DataGrid(query);
        }
    }
}


