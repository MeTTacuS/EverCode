using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace What_s_That
{
    class Login
    {
        public string Username { get; private set; }
        public string Userpassword { get; private set; }

        public Login(string user, string pass)
        {
            Username = user;
            Userpassword = pass;
        }

        private bool StringValidator(string input)
        {
            string pattern = "[^a-zA-Z]";
            return Regex.IsMatch(input, pattern);
        }

        private bool IntegerValidator(string input)
        {
            string pattern = "[^0-9]";
            return Regex.IsMatch(input, pattern);
        }

        private void ClearTexts(string user, string pass)
        {
            user = String.Empty;
            pass = String.Empty;
        }

        internal bool IsLoggedIn(string user, string pass)
        {
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Enter the user name!");
                return false;
            }
            else if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Enter the passowrd!");
                return false;
            }

            else if (StringValidator(user) || IntegerValidator(pass))
            {
                MessageBox.Show("Incorrent format");
                ClearTexts(user, pass);
                return false;
            }

            else if (Username != user || Userpassword != pass)
            {
                MessageBox.Show("Username or password is incorrect!");
                ClearTexts(user, pass);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
