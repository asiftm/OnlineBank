﻿using MySqlConnector;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
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

        //constructors
        public Account()
        {

        }
        public Account(int _accountNumber, int _userId, decimal _balance) : base(_userId)
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
            if (result.HasRows == false)
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

        public void GetAccount(DataGridView dataGridView, User user)
        {
            string query = $"SELECT AccountNumber,Balance FROM `accounts` where UserID={user.ID};";
            data.FillDataGrid(dataGridView, query);
        }

        public bool VerifyAccount(string account)
        {
            bool temp = false;
            string query = $"SELECT * FROM `accounts` WHERE AccountNumber='{account}'";
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
    }
}