using MySqlConnector;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
            string query = $"select * from accounts where accountnumber='BE{rNum}'";
            MySqlDataReader result = data.SelectQuery(query);
            if (result.HasRows==false)
            {
                temp = true;
            }
            return temp;
        }
        public bool CreateAccount(User user, string rNum, string iBal)
        {
            bool temp = false;
            string query = $"INSERT INTO `accounts` (`AccountNumber`, `UserID`, `Balance`) VALUES ('BE{rNum}', '{user.ID}', '{iBal}');";
            if (data.NonSelectQuery(query) == 1)
            {
                temp = true;
            };
            return temp;
        }
        
        public int GenerateAccountNumber(User user)
        {
            bool temp = false;
            int rNum = 0;
            int loop = 1;
            while (temp == false)
            {
                Random random = new Random(user.ID);
                for (int i = 0; i < loop; i++)
                {
                    rNum = random.Next(1000000, 9999999);
                }
                temp = PreviousAccountNumberCheck(rNum);
                loop++;
            }
            return rNum;
        }
        
        
    }
}
