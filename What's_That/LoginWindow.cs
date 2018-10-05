using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace What_s_That
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        //Enter code here for your version of username and userpassword 
        Login login = new Login("admin", "1234");

        private void loginButton_Click(object sender, EventArgs e)
        {

            //define local variables from the user inputs 
            string user = username_TextBox.Text;
            string pass = password_TextBox.Text;

            //check if eligible to be logged in 
            if (login.IsLoggedIn(user, pass))
            {
                MessageBox.Show("You are logged in successfully");
                this.Hide();
                var main_window = new MainWindow();
                main_window.Closed += (s, args) => this.Close();
                main_window.Show();
            }
            else
            {
                //show default login error message 
                MessageBox.Show("Login Error!");
            }
           
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }

        private void username_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextBox_TextChanged(object sender, EventArgs e)
        {
            password_TextBox.PasswordChar = '#';
        }

        private void password_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Under development");
        }

        private void register_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Under development");
        }
    }
}
