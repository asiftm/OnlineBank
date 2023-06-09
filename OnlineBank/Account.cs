using MySqlConnector;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBank
{
    class Account : User
    {
        Data data = new Data();

        //properties
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public bool AccountStatus { get; set; }

        //constructors
        public Account()
        {

        }
        public Account(int _accountNumber, int _userId, decimal _balance, bool accountStatus) : base(_userId)
        {
            AccountNumber = _accountNumber;
            Balance = _balance;
            AccountStatus = accountStatus;
        }

        //methods
        public bool PreviousAccountNumberCheck(int rNum)
        {
            bool temp = false;
            string query = $"select * from accounts where accountnumber='BE{rNum}'";
            MySqlDataReader result = data.SelectQuery(query);
            if (result.HasRows == false)
            {
                temp = true;
            }
            return temp;
        }
        public bool CreateAccount(User user, string rNum, string iBal)
        {
            bool temp = false;
            string query = $"INSERT INTO `accounts` (`AccountNumber`, `UserID`, `Balance`, `Status`) VALUES ('BE{rNum}', '{user.ID}', '{iBal}', '1');";
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
        public void GetAccounts(DataGridView dataGridView, User user)
        {
            string query = $"SELECT AccountNumber,Balance,Status FROM `accounts` where UserID='{user.ID}';";
            data.FillDataGrid(dataGridView, query);
        }
        public bool VerifyUserAccount(string account,User user)
        {
            bool temp = false;
            string query = $"SELECT * FROM `accounts` WHERE AccountNumber='{account}' and UserID='{user.ID}';";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                if (result[0].ToString() == account)
                {
                    temp = true;
                }
            }
            return temp;
        }public bool VerifyAccount(string account)
        {
            bool temp = false;
            string query = $"SELECT * FROM `accounts` WHERE AccountNumber='{account}';";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                if (result[0].ToString() == account)
                {
                    temp = true;
                }
            }
            return temp;
        }
        public double CheckBalance(string account)
        {
            double balance = 0;
            string query = $"SELECT * FROM `accounts` WHERE AccountNumber='{account}';";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                if (result[0].ToString() == account)
                {
                    balance = Convert.ToDouble(result[2]);
                }
            }
            return balance;
        }
        public bool ChangeBalance(string account, double amount)
        {
            bool temp = false;
            string query = $"UPDATE `accounts` SET `Balance` = '{amount}' WHERE `accounts`.`AccountNumber` = '{account}';";
            if (data.NonSelectQuery(query) == 1)
            {
                temp = true;
            }
            return temp;
        }
        public bool UserAccountCheck(User user)
        {
            bool temp = false;
            string query = $"SELECT * FROM `accounts` WHERE UserID='{user.ID}';";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                if (Convert.ToInt32(result[1].ToString()) >= 1)
                {
                    temp = true;
                }
            }
            return temp;
        }
        public bool EnableStatusCheck(string account)
        {
            bool status = false;
            string query = $"SELECT * FROM `accounts` WHERE AccountNumber='{account}' and Status = '1';";
            MySqlDataReader result = data.SelectQuery(query);
            if(result.HasRows)
            {
                status = true;
            }
            return status;
        }
        public bool DisableStatusCheck(string account)
        {
            bool status = false;
            string query = $"SELECT * FROM `accounts` WHERE AccountNumber='{account}' and Status = '0';";
            MySqlDataReader result = data.SelectQuery(query);
            if (result.HasRows)
            {
                status = true;
            }
            return status;
        }
        public bool ChangeStatus(string account,string status)
        {
            bool temp = false;
            string query = $"UPDATE `accounts` SET `Status` = '{status}' WHERE `accounts`.`AccountNumber` = '{account}';";
            if (data.NonSelectQuery(query) == 1)
            {
                temp = true;
            }
            return temp;
        }
    }
}

