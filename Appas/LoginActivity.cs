using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Appas
{
    [Activity(Label = "LoginActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]

    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_layout);

            var user = FindViewById<EditText>(Resource.Id.username);
            var pass = FindViewById<EditText>(Resource.Id.password);
            Button loginas = FindViewById<Button>(Resource.Id.loginas);
            Button registeris = FindViewById<Button>(Resource.Id.registrationas);

            registeris.Click += delegate
            {
                StartActivity(typeof(RegistrationActivity));
            };

            loginas.Click += delegate
            {
                LoginValidation lv = new LoginValidation(user.Text, pass.Text);
                Lazy <Counter> tries = new Lazy<Counter>();
                lv.Validation += Onvalidation;
                lv.CheckValidation();
            };
        }

        public void Onvalidation(object sender, ValidationEventArgs e)
        {
            if(e.Valide)
                StartActivity(typeof(MainActivity));
            else
                Toast.MakeText(this, "login is not valide, please try again", ToastLength.Long).Show();
        }
    }

    public class LoginValidation
    {
        string userpattern = "^[A-Za-z]{3,}$", passpattern = "^[0-9]{3,}$";
        string loginname = "Admin", loginpass = "1410";
        bool username, password;

        public LoginValidation(string user, string pass)
        {
            username = !string.IsNullOrEmpty(user) && Regex.IsMatch(user, userpattern) && loginname == user;
            password = !string.IsNullOrEmpty(pass) && Regex.IsMatch(pass, passpattern) && loginpass == pass;
        }

        public void CheckValidation()
        {
            Onvalidation(username && password);
        }

        public event EventHandler<ValidationEventArgs> Validation;

        protected virtual void Onvalidation(bool isValide)
        {
            if(Validation !=null)
                Validation(this, new ValidationEventArgs() { Valide = isValide });
        }

    }

    public class ValidationEventArgs : EventArgs
    {
        public bool Valide { get; set; }
    }

    public class Counter
    {
        public Counter()
        {
            Tries = 0;
        }
        public static int Tries { get; set; }
    }
}