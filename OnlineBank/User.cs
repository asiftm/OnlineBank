using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnlineBank
{
    public class User
    {
        Data data = new Data();

        //properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        //constructors
        public User()
        {

        }

        public User(int _id)
        {
            ID = _id;
        }

        public User (string _firstName,string _lastName,string _password,string _dateOfBirth,string _email,string _address)
        {
            FirstName = _firstName;
            LastName = _lastName;
            Password = _password;
            DateOfBirth = _dateOfBirth;
            Email = _email;
            Address = _address;
        }

        public User(int _id,string _firstName, string _lastName, string _password, string _dateOfBirth, string _email, string _address)
        {
            ID = _id;
            FirstName = _firstName;
            LastName = _lastName;
            Password = _password;
            DateOfBirth = _dateOfBirth;
            Email = _email;
            Address = _address;
        }

        //methods
        public bool VerifyUser(User user)
        {
            bool temp = false;
            string query = $"select * from user where Email='{user.Email}' and Password='{user.Password}'";
            Console.WriteLine(query);
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

        public bool PreviousAccountCheck(User user)
        {
            bool temp = false;
            string query = $"select * from user where Email='{user.Email}'";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                if (Convert.ToInt32(result[0].ToString())>=1)
                {
                    temp = true;
                }
            }
            return temp;
        }

        public bool CreateUser(User user)
        {
            bool temp = false;
            string query = $"INSERT INTO `user` (`FirstName`, `LastName`, `Password`, `DateOfBirth`, `Email`, `Address`) VALUES('{user.FirstName}', '{user.LastName}', '{user.Password}', '{user.DateOfBirth}', '{user.Email}', '{user.Address}');";
            if(data.NonSelectQuery(query)==1)
            {
                temp=true;
            };
            return temp;
        }

        public User GetUser(string email)
        {
            User user = new User();
            string query = $"select * from `user` where Email='{email}'";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                user.ID = (int)result[0];
                user.FirstName = result[1].ToString();
                user.LastName = result[2].ToString();
                user.Password = result[3].ToString();
                user.DateOfBirth = result[4].ToString().Split(' ')[0];
                user.Email = result[5].ToString();
                user.Address = result[6].ToString();
            }
            return user;
        }

        public bool UpdateUser(User user)
        {
            bool temp = false;
            string query = $"UPDATE `user` SET `FirstName` = '{user.FirstName}', `LastName` = '{user.LastName}', `Password` = '{user.Password}', `DateOfBirth` = '{user.DateOfBirth}', `Email` = '{user.Email}', `Address` = '{user.Address}' WHERE `user`.`ID` = {user.ID}";
            if (data.NonSelectQuery(query) == 1)
            {
                temp = true;
            }
            return temp;
        }

        public bool DeleteUser(User user)
        {
            bool temp = false;
            String query = $"DELETE FROM user WHERE user.FirstName='{user.FirstName}'";
            if (data.NonSelectQuery(query) == 1)
            {
                temp = true;
                MessageBox.Show("Account deleted successful!");
                AccountDelete accountDelete = new AccountDelete();
                accountDelete.Hide();
                LogInPage logInPage = new LogInPage();
                logInPage.Show();
            };
            return temp;
        }
    }
}
