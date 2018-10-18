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

        Panel activePanel;
        String username = " Username";
        String password = " Password";
        String email = " Email";

        //Enter code here for your version of username and userpassword 
        Login login = new Login("admin", "1234567");
       
        void ClickOnLoginButton(object sender, EventArgs e)
        {
            var user = usernameTextBox.Text;
            var pass = passwordTextBox.Text;

            if (login.IsLoggedIn(user, pass))
            {
                this.Hide();
                var main_window = new MainWindow();
                main_window.Closed += (s, args) => this.Close();
                main_window.Show();
            }
            else
            {
                SetTextOnTextBox(usernameTextBox, username);
                SetTextOnTextBox(passwordTextBox, password);
            }
        }

        void LoginWindowLoad(object sender, EventArgs e)
        {
            SetTextOnTextBox(usernameTextBox, username);
            SetTextOnTextBox(passwordTextBox, password);

            registrationPanel.Location = loginPanel.Location;
            activePanel = loginPanel;
            registrationPanel.Visible = false;
        }

        new void Enter(TextBox textBox)
        {
            if (textBox.ForeColor == Color.FromArgb(203, 204, 198))
                return;
            textBox.Text = String.Empty;
            textBox.ForeColor = Color.FromArgb(203, 204, 198);
        }

        new void Leave(TextBox textBox, String value)
        {
            if (textBox.Text.Trim() == "")
            {
                SetTextOnTextBox(textBox, value);
            }
        }

        protected void SetTextOnTextBox(TextBox textBox, String value)
        {
            textBox.Text = value;
            textBox.ForeColor = Color.Gray;
        }

        void EnterOnUsernameTextBox(object sender, EventArgs e) =>
            Enter(usernameTextBox);

        void LeaveOnUsernameTextBox(object sender, EventArgs e) =>
           Leave(usernameTextBox, username);

        void EnterOnPasswordTextBox(object sender, EventArgs e)
        {
            Enter(passwordTextBox);
            passwordTextBox.PasswordChar = '●';
        }

        void LeaveOnPasswordTextBox(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Trim() == "")
            {
                passwordTextBox.PasswordChar = '\0';
                SetTextOnTextBox(passwordTextBox, password);
            }
        }

        void LinkClickedPasswordLabel(object sender, LinkLabelLinkClickedEventArgs e) =>
            MessageBox.Show("Under development");

        private void ClickOnRegisterButton(object sender, EventArgs e)
        {
            SetTextOnTextBox(registrationUsernameTextBox, username);
            SetTextOnTextBox(registrationEmailTextBox, email);
            SetTextOnTextBox(registrationPasswordTextBox, password);

            activePanel.Visible = false;
            activePanel = registrationPanel;
            activePanel.Visible = true;
        }




        private void EnterOnRegistrationUsernameTextBox(object sender, EventArgs e) =>
            Enter(registrationUsernameTextBox);

        private void LeaveOnRegistrationUsernameTextBox(object sender, EventArgs e) =>
          Leave(registrationUsernameTextBox, username);

        private void EnterOnRegistrationEmailTextBox(object sender, EventArgs e) =>
            Enter(registrationEmailTextBox);

        private void LeaveOnRegistrationEmailTextBox(object sender, EventArgs e) =>
            Leave(registrationEmailTextBox, email);

        private void EnterOnRegistrationPasswordTextBox(object sender, EventArgs e)
        {
            Enter(registrationPasswordTextBox);
            registrationPasswordTextBox.PasswordChar = '●';
        }

        private void LeaveOnRegistrationPasswordTextBox(object sender, EventArgs e)
        {
            if (registrationPasswordTextBox.Text.Trim() == "")
            {
                registrationPasswordTextBox.PasswordChar = '\0';
                SetTextOnTextBox(registrationPasswordTextBox, password);
            }
        }

        private void ClickOnFacebookLabel(object sender, EventArgs e) => 
            MessageBox.Show("Under development");

        private void ClickOnBackToLoginButton(object sender, EventArgs e)
        {
            activePanel.Visible = false;
            activePanel = loginPanel;
            activePanel.Visible = true;
        }
    }
}
