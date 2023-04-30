using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace OnlineBank
{
    internal class Data
    {
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bank;";
        MySqlConnection connection;
        MySqlCommand command;

        public void OpenConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        public void CloseConnection()
        {
            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        
        public MySqlDataReader SelectQuery(string query)
        {
            OpenConnection();
            command = new MySqlCommand(query,connection);
            return command.ExecuteReader();
        }

        public int NonSelectQuery(string qurey)
        {
            try
            {
                OpenConnection();
                command = new MySqlCommand(qurey,connection);
                int temp = command.ExecuteNonQuery();
                connection.Close();
                return temp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
            
        }
    }
}
