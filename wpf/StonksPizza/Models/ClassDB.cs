using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace StonksPizza.Models
{
    public class ClassDB
    {
        MySqlConnection _conn = new MySqlConnection("Server=localhost;Database=stonkpizza;Uid=root;Pwd=;");

        public List<DBaccounts> GetAllAccounts()
        {
            List<DBaccounts> result = new List<DBaccounts>();
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "SELECT * FROM accounts";

                MySqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach (DataRow row in table.Rows)
                {
                    DBaccounts accounts = new DBaccounts();
                    accounts.AccountID = (int)row["accountid"];
                    accounts.VolledigeNaam = (string)row["volledigenaam"];
                    accounts.Wachtwoord = (string)row["wachtwoord"];
                    accounts.IsManager = (bool)row["ismanager"];
                    result.Add(accounts);
                }
            }
            catch (Exception e)
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

        public List<DBbestellingen> GetAllBestellingen()
        {
            List<DBbestellingen> result = new List<DBbestellingen>();
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "SELECT * FROM Orders";

                MySqlDataReader reader = sql.ExecuteReader();
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

        public List<DBunits> GetAllUnits()
        {
            List<DBunits> result = new List<DBunits>();
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "SELECT * FROM units";

                MySqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach (DataRow row in table.Rows)
                {
                    DBunits units = new DBunits();
                    units.UnitID = (int)row["unitID"];
                    units.Unit = (int)row["unit"];
                    result.Add(units);
                }
            }
            catch (Exception e)
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

        public List<DBitems> GetAllItems()
        {
            List<DBitems> result = new List<DBitems>();
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "SELECT * FROM items";

                MySqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach(DataRow row in table.Rows)
                {
                    DBitems items = new DBitems();
                    items.ItemID = (int)row["itemID"];
                    items.ItemName = (string)row["itemName"];
                    items.ItemCount = (string)row["itemCount"];
                    items.ItemPrice = (double)row["itemPrice"];
                    result.Add(items);
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
            finally
            {
                if(_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return result;
        }

        public DBbestellingen GetSpecificBestelling(int bestellingid)
        {
            DBbestellingen result = new DBbestellingen();
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "SELECT * FROM orders WHERE BestellingID = @bestellingid";
                sql.Parameters.AddWithValue("@bestellingid", bestellingid);
                MySqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach (DataRow row in table.Rows)
                {
                    result.BestellingID = (int)row["bestellingID"];
                    result.BestellingContent = (string)row["bestellingContent"];
                    result.Status = (string)row["status"];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("***SpecificInBestelling***");
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

        public DBunits GetSpecificUnit(int unitid)
        {
            DBunits result = new DBunits();
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "SELECT * FROM units WHERE UnitID = @unitid";
                sql.Parameters.AddWithValue("@unitid", unitid);
                MySqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach (DataRow row in table.Rows)
                {
                    result.UnitID = (int)row["unitid"];
                    result.Unit = (int)row["unit"];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("***SpecificInUnits***");
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

        public DBitems GetSpecificItem(int itemid)
        {
            DBitems result = new DBitems();
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "SELECT * FROM items WHERE ItemID = @itemid";
                sql.Parameters.AddWithValue("@itemid", itemid);
                MySqlDataReader reader = sql.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                foreach(DataRow row in table.Rows)
                {
                    result.ItemID = (int)row["itemID"];
                    result.ItemName = (string)row["itemName"];
                    result.ItemCount = (string)row["itemCount"];
                    result.ItemPrice = (double)row["itemPrice"];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("***SpecificInItems***");
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

        public bool CreateUnit(DBunits units)
        {
            bool result = true;
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "INSERT INTO units (unit) VALUES (@unit)";
                sql.Parameters.AddWithValue("@unit", units.Unit);
                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("***InsertInUnits***");
                Console.Write(e);
                result = false;
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

        public bool CreateItem(DBitems items)
        {
            bool result = true;
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "INSERT INTO items (ItemName, ItemCount, ItemPrice) VALUES (@itemname, @itemcount, @itemprice)";
                sql.Parameters.AddWithValue("@itemname", items.ItemName);
                sql.Parameters.AddWithValue("@itemcount", items.ItemCount);
                sql.Parameters.AddWithValue("@itemprice", items.ItemPrice);
                sql.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("***InsertInItems***");
                Console.Write(e);
                result = false;
            }
            finally
            {
                if(_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return result;
        }

        public bool EditBestelling(DBbestellingen bestelling)
        {
            bool result = true;
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "UPDATE orders SET BestellingContent = @bestellingcontent, Status = @status WHERE BestellingID = @bestellingid";
                sql.Parameters.AddWithValue("@bestellingid", bestelling.BestellingID);
                sql.Parameters.AddWithValue("@bestellingcontent", bestelling.BestellingContent);
                sql.Parameters.AddWithValue("@status", bestelling.Status);
                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("***EditInBestelling***");
                Console.Write(e);
                result = false;
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

        public bool EditUnit(DBunits units)
        {
            bool result = true;
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "UPDATE units SET Unit = @unit WHERE UnitID = @unitid";
                sql.Parameters.AddWithValue("@unitid", units.UnitID);
                sql.Parameters.AddWithValue("@unit", units.Unit);
                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("***EditInUnit***");
                Console.Write(e);
                result = false;
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

        public bool EditItem(DBitems items)
        {
            bool result = true;
            try
            {
                _conn.Open();
                MySqlCommand sql = _conn.CreateCommand();
                sql.CommandText = "UPDATE items SET ItemName = @itemname, ItemCount = @itemcount, ItemPrice = @itemprice WHERE ItemID = @itemid";
                sql.Parameters.AddWithValue("itemid", items.ItemID);
                sql.Parameters.AddWithValue("@itemname", items.ItemName);
                sql.Parameters.AddWithValue("@itemcount", items.ItemCount);
                sql.Parameters.AddWithValue("@itemprice", items.ItemPrice);
                sql.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("***EditInItems***");
                Console.Write(e);
                result = false;
            }
            finally
            {
                if(_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return result;
        }

        public void DeleteItem(DBitems items)
        {
            _conn.Open();
            MySqlCommand sql = _conn.CreateCommand();
            if(items.ItemID > 0)
            {
                sql.CommandText = "DELETE FROM items WHERE ItemID = @itemid";
            }
            sql.Parameters.AddWithValue("@itemid", items.ItemID);
            sql.ExecuteReader();
            _conn.Close();
        }

        public void DeleteUnit(DBunits units)
        {
            _conn.Open();
            MySqlCommand sql = _conn.CreateCommand();
            if (units.UnitID > 0)
            {
                sql.CommandText = "DELETE FROM units WHERE UnitID = @unitid";
            }
            sql.Parameters.AddWithValue("@unitid", units.UnitID);
            sql.ExecuteReader();
            _conn.Close();
        }

        public void DeleteBestelling(DBbestellingen bestelling)
        {
            _conn.Open();
            MySqlCommand sql = _conn.CreateCommand();
            if (bestelling.BestellingID > 0)
            {
                sql.CommandText = "DELETE FROM orders WHERE BestellingID = @bestellingid";
            }
            sql.Parameters.AddWithValue("@bestellingid", bestelling.BestellingID);
            sql.ExecuteReader();
            _conn.Close();
        }
    }
}
