using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        const int RequestLocationId = 0;

        readonly string[] PermissionsGroupLocation =
        {
            Android.Manifest.Permission.Camera
        };

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_layout);
            await TryToGetPermissions();

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

            try
            {
                Android.Graphics.Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                var recognizer = new FaceRecognizer();
                recognizer.OnRecognized += FaceRecognized;
                recognizer.RecognizeFace(bitmap);
            }
            catch (Exception e) { }
            
        }


        private void OnRecognizeClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }


        private void FaceRecognized(object source, FaceRecognizedEventArgs e)
        {
            IDobj.ID = e.userID;
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

        async Task TryToGetPermissions()
        {
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                await GetPermissionsAsync();
                return;
            }
        }

        async Task GetPermissionsAsync()
        {
            const string permission = Android.Manifest.Permission.Camera;

            if (CheckSelfPermission(permission) == (int)Android.Content.PM.Permission.Granted)
            {
                //  Toast.MakeText(this, "Permission granted", ToastLength.Short).Show();
                return;
            }

            if (ShouldShowRequestPermissionRationale(permission))
            {
                //set Alert for executing task
                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                alert.SetTitle("Permission Needed");
                alert.SetMessage("Need permission to continue");
                alert.SetPositiveButton("Request permission", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionsGroupLocation, RequestLocationId);
                });

                alert.SetNegativeButton("Cancel", (sendAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelled", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();

                return;
            }
            RequestPermissions(PermissionsGroupLocation, RequestLocationId);
        }

    }

    static class IDobj
    {
        public static int ID { get; set; }
    }
}