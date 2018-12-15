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
using Java.Lang;


namespace Appas.Resources
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtDate { get; set; }
    }

    public class HistoryAdapter : BaseAdapter
    {
        private Android.Support.V4.App.Fragment _fragment;
        private List<History> _history;

        public HistoryAdapter(Android.Support.V4.App.Fragment fragment, List<History> history)
        {
            _fragment = fragment;
            _history = history;
        }

        public override int Count
        {
            get
            {
                return _history.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return _history[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _fragment.LayoutInflater.Inflate(Resource.Layout.history_list_view_dataTemplate, parent, false);
            var txtName = view.FindViewById<TextView>(Resource.Id.nameTextView);
            var txtDate = view.FindViewById<TextView>(Resource.Id.dateTextView);

            txtName.Text = _history[position].Name;
            txtDate.Text = _history[position].Date.ToString();

            return view;
        }
    }
}