using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Appas.RecognitionHandler;

namespace Appas.Fragments
{
    public class PersonFragment : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.account_layout, container, false);
            Button delete = view.FindViewById<Button>(Resource.Id.DeleteButton);

            delete.Click += async (sender, e) =>
            {
                Console.WriteLine(" ----------------------------------------------------------------------" + IDobj.ID + "---------------------------------------------------------------------------");
                string x = await FaceRecognizer.DeletePerson(2);
                Console.WriteLine("AR METODAS MAN PAVYKO " + x + "----------------------------------------------------------------------------------------------------------------------");
            };

            return view;
        }
    }
}