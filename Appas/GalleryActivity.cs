using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    [Activity(Label = "GalleryActivity")]
    public class GalleryActivity : Activity
    {
        const int RequestLocationId = 0;
        Bitmap bitmap;
        readonly string[] PermissionsGroupLocation =
        {
            Android.Manifest.Permission.Camera
        };

        ImageView imageView;
        Button _openCamera;

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.demo_layout);
            await TryToGetPermissions();

            var button = FindViewById<Button>(Resource.Id.mygallery);
            imageView = FindViewById<ImageView>(Resource.Id.myphoto);
            _openCamera = FindViewById<Button>(Resource.Id.openCamera);

            button.Click += delegate {

                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };

            _openCamera.Click += BtnCamera_Click;
        }

        private void BtnCamera_Click(object senderm, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 1);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if(requestCode == 0)
            {
                base.OnActivityResult(requestCode, resultCode, data);
                if (resultCode == Result.Ok)
                    {
                        imageView.SetImageURI(data.Data);
                    }
            }else if(requestCode == 1)
            {
                base.OnActivityResult(requestCode, resultCode, data);

                try
                {
                    bitmap = (Bitmap)data.Extras.Get("data");
                    imageView.SetImageBitmap(bitmap);

                    var recognizer = new FaceRecognizer();
                    recognizer.OnRecognized += FaceRecognized;
                    recognizer.RecognizeFace(bitmap);

                }
                catch (Exception e) { }
            }
            
        }

        private void FaceRecognized(object source, FaceRecognizedEventArgs e)
        {
            var seenID = e.userID;
            if (seenID != 0)
            {
                Toast.MakeText(ApplicationContext, "who seen: " + IDobj.ID + "who was seen: " + seenID + " date: " + DateTime.Now, ToastLength.Long).Show();
                ApiRequestsUtils.AddWhoSawWhoAsync( IDobj.ID, seenID, DateTime.Now);
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
}