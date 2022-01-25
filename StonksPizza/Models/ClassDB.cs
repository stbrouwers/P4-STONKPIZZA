using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StonksPizza.Models
{
    public class ClassDB
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StonksPizzaConnection"].ConnectionString);

        public List<DBbestellingen> GetAllBestellingen()
        {
            List<DBbestellingen> result = new List<DBbestellingen>();
            try
            {
                _conn.Open();
                SqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "SELECT * FROM Orders";

                SqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach(DataRow row in table.Rows)
                {
                    DBbestellingen bestelling = new DBbestellingen();
                    bestelling.BestellingID = (int)row["bestellingID"];
                    bestelling.UserID = (int)row["userID"];
                    bestelling.BestellingContent = (string)row["bestellingContent"];
                    bestelling.Status = (string)row["status"];
                    result.Add(bestelling);
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return result;
        }
    }
}
