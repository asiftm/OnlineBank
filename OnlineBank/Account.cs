using MySqlConnector;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBank
{
    class Account:User
    {
        Data data = new Data();

        //properties
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        //constructors
        public Account ()
        {
            
        }
        public Account(int _accountNumber, int _userId, decimal _balance):base(_userId)
        {
            AccountNumber = _accountNumber;
            Balance = _balance;
        }

        //methods
        public bool PreviousAccountNumberCheck(int rNum)
        {
            bool temp = false;
            string query = $"select * from accounts where accountnumber='{rNum}'";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                if (Convert.ToInt32(result[0].ToString()) >= 1)
                {
                    temp = true;
                }
            }
            return temp;
        }
        public bool CreateAccount(User user, string rNum, string iBal)
        {
            bool temp = false;
            string query = $"ALUES('INSERT INTO `accounts` (`AccountNumber`, `UserID`, `Balance`) VALUES ('{rNum}', '{user.ID}', '{iBal}');";
            if (data.NonSelectQuery(query) == 1)
            {
                temp = true;
            };
            return temp;
        }
        
        public void GetAccountNumber(User user)
        {


        }
    }
}
