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
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Appas.APIUtils;
using Appas.Request_Models;

namespace Appas.Fragments
{
    public class HistoryFragment : Android.Support.V4.App.Fragment
    {
        List<HistoryModel> lstSource = new List<HistoryModel>();
        ListView lstData;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override void OnStart()
        {
            base.OnStart();

           lstData = View.FindViewById<ListView>(Resource.Id.historyView);
          
            var showHistoryBtn = View.FindViewById<Button>(Resource.Id.btnShow);
            var _startDateButton = View.FindViewById<Button>(Resource.Id.startDateButton);
            var _endDateButton = View.FindViewById<Button>(Resource.Id.endDateButton);
            var _startDate = new DateTime(1990, 1, 1);
            var _endDate = new DateTime();
            DateTime _today = DateTime.Today;
            

            _endDate = DateTime.Today;

            _startDateButton.Click += delegate
            {
                DatePickerDialog dialog = new DatePickerDialog(this.Activity, OnStartDateSet, _today.Year, _today.Month - 1, _today.Day);
                dialog.DatePicker.MinDate = _today.Millisecond;
                dialog.Show();
            };

            _endDateButton.Click += delegate
            {
                DatePickerDialog dialog = new DatePickerDialog(this.Activity, OnEndDateSet, _today.Year, _today.Month - 1, _today.Day);
                dialog.DatePicker.MinDate = _today.Millisecond;
                dialog.Show();
            };
           
            
            void OnStartDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
            {
                _startDate = e.Date;
               
            }

            void OnEndDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
            {
                _endDate = e.Date;
            }

            showHistoryBtn.Click += async delegate
            {
                // List<History> lstSource = new List<History>();
                lstSource.Clear();
                try
                {
lstSource = await ApiRequestsUtils.GetLatestHistoryAsync(IDobj.ID);

                }
                catch(Exception e)
                {

                }

              //  for (int i = 0; i < 3; i++)
               // {

                /*    History dataCs = new History()
                    {
                        Id = i,
                        Name = "abcde" + i,
                        Date = DateTime.Parse("2018-12-05").AddDays(i),
                        Vote = i
                    };*/
                   //    if (dataCs.Date >= _startDate && dataCs.Date <= _endDate)
                   // lstSource.Add(dataCs);
                //}
                if(lstSource != null)
                {
var adapter = new HistoryAdapter(this, lstSource);
                lstData.Adapter = adapter;
                }
                
            };

            lstData.ItemClick += mListView_ItemClick;

        }

        //UPVOTING

        private void mListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)       
        {
            Toast.MakeText(this.Activity, lstSource[e.Position].points.ToString(), ToastLength.Short).Show();
            lstSource[e.Position].points += 1;
            var adapter = new HistoryAdapter(this, lstSource);
                lstData.Adapter = adapter;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.history_layout, container, false);
            return view;
        }
    }
}