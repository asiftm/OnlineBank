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
using System.IO;

namespace OnlineBank
{
    internal class Data
    {
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=1234;database=bank;";
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
                return temp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("An error occured!\nPlease try again.");
            }
            return 0;
        }
        public DataTable DataGrid(string query)
        {
            DataTable dataTable = new DataTable();
            OpenConnection();
            command = new MySqlCommand(query,connection);
            MySqlDataReader mySqlDataReader = command.ExecuteReader();
            dataTable.Load(mySqlDataReader);
            return dataTable;
        }
        public int InsertImage(User user, string query)
        {
            try
            {
                if (user.Image != null)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    user.Image.Save(memoryStream, user.Image.RawFormat);
                    byte[] img = memoryStream.ToArray();

                    command = new MySqlCommand(query, connection);
                    command.Parameters.Add("@image", MySqlDbType.Blob).Value = img;
                }
                else
                {
                    command = new MySqlCommand(query, connection);
                    command.Parameters.Add("@image", MySqlDbType.Blob).Value = DBNull.Value;
                }
                OpenConnection();
                int temp = command.ExecuteNonQuery();
                connection.Close();
                return temp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("An error occured!\nPlease try again.");
            }
            return 0;
        }
        public int InsertAdminImage(Admin admin, string query)
        {
            try
            {
                if (admin.Image != null)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    admin.Image.Save(memoryStream, admin.Image.RawFormat);
                    byte[] img = memoryStream.ToArray();

                    command = new MySqlCommand(query, connection);
                    command.Parameters.Add("@image", MySqlDbType.Blob).Value = img;
                }
                else
                {
                    command = new MySqlCommand(query, connection);
                    command.Parameters.Add("@image", MySqlDbType.Blob).Value = DBNull.Value;
                }

                OpenConnection();
                int temp = command.ExecuteNonQuery();
                connection.Close();
                return temp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("An error occured!\nPlease try again.");
            }
            return 0;
        }
    }
}
