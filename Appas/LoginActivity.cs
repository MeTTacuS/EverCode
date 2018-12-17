using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Appas.RecognitionHandler;

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

            loginas.Click += OnRecognizeClick;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Android.Graphics.Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            var recognizer = new FaceRecognizer();
            recognizer.OnRecognized += FaceRecognized;
            recognizer.RecognizeFace(bitmap);
        }


        private void OnRecognizeClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }


        private void FaceRecognized(object source, FaceRecognizedEventArgs e)
        {
            var userID = e.userID;
            if (userID != 0)
            {
                Toast.MakeText(ApplicationContext, "Face recognized, ID:" + userID, ToastLength.Long).Show();
                var act = new Intent(this, typeof(MainActivity));
                act.PutExtra("UserID", userID.ToString());
                StartActivity(act);
            }
            else
            {
                Toast.MakeText(ApplicationContext, "Face recognition failed", ToastLength.Long).Show();
            }
        }



    }
}