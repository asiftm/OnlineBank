using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBank
{
    public class LoanType
    {
        Data data = new Data();
        public int ID { get; set; }
        public string Type { get; set; }
        public int Interest { get; set; }

        public LoanType()
        {
            
        }
        public LoanType(int id, string type, int period, int interest)
        {
            ID = id;
            Type = type;
            Interest = interest;
        }
        //methods
        public LoanType GetLoanType(int id)
        {
            LoanType loanTypes = new LoanType();
            string query = $"SELECT * FROM bank.loantypes where id = {id}";
            MySqlDataReader result = data.SelectQuery(query);
            while (result.Read())
            {
                loanTypes.ID = result.GetInt32(0);
                loanTypes.Type = result.GetString(1);
                loanTypes.Interest = result.GetInt32(2);
            }
            return loanTypes;
        }
    }
}
