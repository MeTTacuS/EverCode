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
                // cia perduodami duomenys
                // poto prisijungiam jei geri duomenys
                if (true)
                {
                    StartActivity(typeof(MainActivity));
                }
            };
        }
    }
}