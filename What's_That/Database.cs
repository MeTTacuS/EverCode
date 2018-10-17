using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.Text.RegularExpressions;


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
            NpgsqlCommand cmd = new NpgsqlCommand(command, _conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            for (int i = 0; reader.Read(); i++)
            {
                dataItems.Add(reader[0].ToString() + "," + reader[1].ToString() + Environment.NewLine);
            }
            return dataItems;
        }

        public void InsertData(int ID, string name, string lastname, int age = 0)
        {
            if (NumberValidatorID(ID) && NumberValidatorAge(age) &&
                StringValidator(name) && StringValidator(lastname))
            {
                MessageBox.Show("labas");
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO userdata (id, age, name, lastname) VALUES" +
                    " (@a, @b, @c, @d)", _conn);
                cmd.Parameters.AddWithValue("a", ID);
                cmd.Parameters.AddWithValue("b", age);
                cmd.Parameters.AddWithValue("c", name);
                cmd.Parameters.AddWithValue("d", lastname);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Įvesti duomenys buvo neteisingi, bandykite dar kartą");
            }
        }

        private bool NumberValidatorID(int number)
        {
            string pattern = @"^\d{6}$";
            return Regex.IsMatch(number.ToString(), pattern);
        }

        private bool NumberValidatorAge(int number)
        {
            if (number == 0)
                return true;
            string pattern = @"^\d{1,3}$";
            return Regex.IsMatch(number.ToString(), pattern);
        }

        private bool StringValidator(string text)
        {
            string pattern = "[^ a - zA - Z]";
            return Regex.IsMatch(text, pattern);
        }
    }
}
