using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBank
{
    class Account:User
    {
        //properties
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        //constructors
        public Account(int _userId,int _accountNumber, decimal _balance):base(_userId)
        {
            AccountNumber = _accountNumber;
            Balance = _balance;
        }
    }
}
