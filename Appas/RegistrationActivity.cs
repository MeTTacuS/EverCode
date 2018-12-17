using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
    [Activity(Label = "RegistrationActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class RegistrationActivity : Activity
    {
        int userID = 0;
        bool faceAdded = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register_layout);

            var user = FindViewById<EditText>(Resource.Id.reg_user);
            var pass = FindViewById<EditText>(Resource.Id.reg_pass);
            var idButton = FindViewById<Button>(Resource.Id.idGeneration);
            var photoButton = FindViewById<Button>(Resource.Id.takePhoto);
            var confirmButton = FindViewById<Button>(Resource.Id.confirmReg);
            var backButton = FindViewById<Button>(Resource.Id.goBack);

            idButton.Click += RegisterClickedEventHandler;

            backButton.Click += delegate
            {
                StartActivity(typeof(LoginActivity));
            };

            confirmButton.Click += delegate
            {
                //cia suinciam IPA data
                //po to prisijungiam
                StartActivity(typeof(MainActivity));
            };

            photoButton.Click += (sender, e) =>
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            };

        }

        async void RegisterClickedEventHandler(object sender, EventArgs e)
        {
            Toast.MakeText(ApplicationContext, "generuoju nx, palauk", ToastLength.Long).Show();
            userID = 1; // cia turetu buti awaitas su kuriuo sugerenuojam ID

            Toast.MakeText(ApplicationContext, userID.ToString(), ToastLength.Long).Show();

            if (userID != 0)
            {
                Toast.MakeText(ApplicationContext, "Email registered, now add your face!", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(ApplicationContext, "nesugeneravau, eik tu namas!!!", ToastLength.Long).Show();
            }

        }

        /* protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
         {
             base.OnActivityResult(requestCode, resultCode, data);
             if (requestCode == 0 && resultCode == Result.Ok)
             {
                 var image = (Bitmap)data.Extras.Get("data");
                 byte[] bitmapData;
                 using (var stream = new MemoryStream())
                 {
                     image.Compress(Bitmap.CompressFormat.Png, 0, stream);
                     bitmapData = stream.ToArray();
                 }

                 var photoView = FindViewById<ImageView>(Resource.Id.usersPhoto);

                 if (bitmapData != null)
                 {
                     //Convert byte array back into bitmap
                     Bitmap bitmap = BitmapFactory.DecodeByteArray(bitmapData, 0, bitmapData.Length);
                    photoView.SetImageBitmap(bitmap);
                 }
             }
         }*/

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Android.Graphics.Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            var recognizer = new FaceRecognizer();
            Toast.MakeText(ApplicationContext, "iki cia veikia", ToastLength.Short).Show();
            recognizer.OnFaceAdded += FaceAdded;
            recognizer.CreateFaceLogin(bitmap, userID);
            faceAdded = true;
            Toast.MakeText(ApplicationContext, "iki cia veikia taip pat", ToastLength.Short).Show();
        }

        private void FaceAdded(object source, FaceAddedEventArgs e)
        {
            if (userID != 0)
            {
                Toast.MakeText(ApplicationContext, "You are registered, you may now login using face recognition", ToastLength.Long).Show();
            }
        }
    }
}