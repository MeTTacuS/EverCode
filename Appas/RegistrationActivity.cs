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

namespace Appas
{
    [Activity(Label = "RegistrationActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class RegistrationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register_layout);

            var user = FindViewById<EditText>(Resource.Id.reg_user);
            var pass = FindViewById<EditText>(Resource.Id.reg_pass);
            var photoButton = FindViewById<Button>(Resource.Id.takePhoto);
            var confirmButton = FindViewById<Button>(Resource.Id.confirmReg);
            var backButton = FindViewById<Button>(Resource.Id.goBack);

            backButton.Click += delegate
            {
                StartActivity(typeof(LoginActivity));
            };


            photoButton.Click += delegate
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            };

            confirmButton.Click += delegate
            {
                //cia suinciam IPA data
                //po to prisijungiam
                StartActivity(typeof(MainActivity));
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
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
        }
    }
}