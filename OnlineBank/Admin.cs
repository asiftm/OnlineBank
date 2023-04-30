using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBank
{
    internal class Admin
    {
        Data data = new Data();

        //properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //constructor
        public Admin() 
        {

        }

        public Admin(string  name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        public Admin(int id,string name, string email, string password)
        {
            ID = id;
            Name = name;
            Email = email;
            Password = password;
        }

        //methods
        public bool VerifyUser(Admin admin)
        {
            bool temp = false;
            string query = $"select * from admin where Email='{admin.Email}' and Password='{admin.Password}'";
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

    }
}
