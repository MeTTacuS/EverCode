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
        [FlagsAttribute]
        private enum LoginValidation
        {
            entered = 1,
            valide = 2,
            correct = 4,

            empty = 8,
            invalide = 16,
            incorrect = 32
        }

        string userpattern = "^[A-Za-z]{3,}$";
        string passpattern = "^[0-9]{6,}$";

        public string Username { get; private set; }
        public string Userpassword { get; private set; }

        public Login(string user, string pass)
        {
            Username = user;
            Userpassword = pass;
        }

        private int IsEmpty(string value)
        {
            return string.IsNullOrEmpty(value) ? 8 : 1;
        }

        private int IsValide(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern) ? 2 : 16;
        }

        private int IsCorrect(string loginname, string username)
        {
            return loginname == username ? 4 : 32;
        }

        internal bool IsLoggedIn(string user, string pass)
        {
            int username = IsEmpty(user) | IsValide(user, userpattern) | IsCorrect(Username, user);
            int password = IsEmpty(pass) | IsValide(pass, passpattern) | IsCorrect(Userpassword, pass);

            if(username > 7 || password > 7)
            {
                MessageBox.Show(string.Format("username: {0} \n password: {1}", (LoginValidation)username, (LoginValidation)password));
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
