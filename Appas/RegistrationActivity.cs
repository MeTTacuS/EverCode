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
using Appas.APIUtils;
using Appas.RecognitionHandler;

namespace Appas
{
    [Activity(Label = "RegistrationActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class RegistrationActivity : Activity
    {
        int userID = 0;
        bool faceAdded = false;
        string username;
        byte[] bitmapData;
        Android.Graphics.Bitmap bitmap;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register_layout);

            var user = FindViewById<EditText>(Resource.Id.reg_user);
            var pass = FindViewById<EditText>(Resource.Id.reg_pass);
            var photoButton = FindViewById<Button>(Resource.Id.takePhoto);
            var regButton = FindViewById<Button>(Resource.Id.reg_reg);

            photoButton.Click += (sender, e) =>
            {
                username = user.Text;
                Random random = new Random();
                //userID = random.Next(); // cia turetu buti awaitas su kuriuo sugerenuojam ID
                if (userID != 0)
                {
                    Toast.MakeText(ApplicationContext, userID.ToString() + "ID generated, add your face!", ToastLength.Long).Show();
                }
                else
                {
                    //Toast.MakeText(ApplicationContext, "nesugeneravau, eik tu namas!!!", ToastLength.Long).Show();
                }

                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            };

            regButton.Click += async (sender, e) =>
            {
                int userID = await ApiRequestsUtils.RegistratePersonAsync(username, bitmapData);
                //Toast.MakeText(ApplicationContext, "registruoju blet, palauk suka  -----------------------------------------------------------------------> " + x, ToastLength.Short).Show();

                Toast.MakeText(ApplicationContext, userID.ToString() + "ID yra -------------------------------------------!" + userID, ToastLength.Long).Show();

                var recognizer = new FaceRecognizer();
                recognizer.OnFaceAdded += FaceAdded;
                recognizer.CreateFaceLogin(bitmap, userID);
                faceAdded = true;
            };
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
            bitmap = (Bitmap)data.Extras.Get("data");
            
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }

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