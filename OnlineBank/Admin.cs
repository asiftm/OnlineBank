using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
        public Image Image { get; set; }

        //constructor
        public Admin() 
        {

        }
        public Admin(int id,string name, string email, string password, Image image)
        {
            ID = id;
            Name = name;
            Email = email;
            Password = password;
            Image = image;
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
        public Admin GetAdmin(string email) 
        {
            Admin admin = new Admin();
            string query = $"select * from `admin` where Email='{email}'";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                admin.ID = (int)result[0];
                admin.Name = result[1].ToString();
                admin.Email = result[2].ToString();
                admin.Password = result[3].ToString();
                byte[] img;
                try
                {
                    img = (byte[])result[4];
                    if (img.Length > 0)
                    {
                        MemoryStream stream = new MemoryStream(img);
                        admin.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        admin.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    admin.Image = null;
                }
            }
            return admin;
        }
        public DataTable AllUsers()
        {
            string query = $"SELECT `id` as `UserID`,CONCAT(`FirstName`, ' ', `LastName`)as `Fullname`,`email` as `E-mail`FROM user;";
            return data.DataGrid(query);
        }
        public DataTable AccountsPerUser()
        {
            string query = $"SELECT `id` as `UserID`,CONCAT(`FirstName`, ' ', `LastName`)as `Fullname`,`email` as `E-mail`FROM user;";
            return data.DataGrid(query);
        }

    }
}
