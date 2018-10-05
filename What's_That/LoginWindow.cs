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

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main_window = new MainWindow();
            main_window.Closed += (s, args) => this.Close();
            main_window.Show();
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
