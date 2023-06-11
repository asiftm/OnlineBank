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

        public void FillComboBox(ComboBox comboBox,string query)
        {
            MySqlDataReader result = SelectQuery(query);
            while(result.Read())
            {
                comboBox.Items.Add(result[0].ToString());
            }
        }

        public void FillDataGrid(DataGridView dataGridView,string query)
        {
            OpenConnection();
            command = new MySqlCommand(query,connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView.DataSource = dataSet.Tables[0];
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
                MemoryStream memoryStream = new MemoryStream();
                user.Image.Save(memoryStream, user.Image.RawFormat);
                byte[] img = memoryStream.ToArray();

                command = new MySqlCommand(query,connection);
                command.Parameters.Add("@image",MySqlDbType.Blob).Value = img;
            
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
