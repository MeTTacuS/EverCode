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
using Appas.Resources;

namespace Appas.Fragments
{
    public class PopularFragment : Android.Support.V4.App.Fragment
    {
        List<Popular> lstSource = new List<Popular>();
        ListView lstData;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override void OnStart()
        {
            base.OnStart();

            lstData = View.FindViewById<ListView>(Resource.Id.popularView);
            var showPopularBtn = View.FindViewById<Button>(Resource.Id.popularButton);

            showPopularBtn.Click += delegate
            {
                lstSource.Clear();

                for(int i = 0; i < 5; i++)
                {
                    Popular dataCs = new Popular() {
                        Id = i,
                        Name = "aa" + i,
                        Vote = i
                    };
                    lstSource.Add(dataCs);
                }
                var adapter = new PopularAdapter(this, lstSource);
                lstData.Adapter = adapter;
            };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            // return base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.popular_layout, container, false);
            return view;
        }
    }
}