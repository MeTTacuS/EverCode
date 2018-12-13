using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Appas
{
    [Activity(Label = "GalleryActivity")]
    public class GalleryActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.demo_layout);

            var button = FindViewById<Button>(Resource.Id.mygallery);

            button.Click += delegate {

                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {

                var imageView = FindViewById<ImageView>(Resource.Id.myphoto);
                imageView.SetImageURI(data.Data);
            }
        }


    }
}