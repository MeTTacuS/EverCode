using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace What_s_That
{
    class Database
    {
        #region Variables
        NpgsqlConnection _conn;
        #endregion

        public Database(string host, string username, string password, string database)
        {
            string connString = "Host = " + host + "; Username = "
                + username + "; Password = " + password + "; Database = " + database;
            _conn = new NpgsqlConnection(connString);
            _conn.Open();
        }

        public List<string> RetrieveData(string command)
        {
            List<string> dataItems = new List<string>();
            command = "SELECT * FROM userdata";
            NpgsqlCommand cmd = new NpgsqlCommand(command, _conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            for (int i = 0; reader.Read(); i++)
            {
                dataItems.Add(reader[0].ToString() + "," + reader[1].ToString() + Environment.NewLine);
            }
            return dataItems;
        }
    }
}
