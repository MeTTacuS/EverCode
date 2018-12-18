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
    public class ViewHolder1 : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtVote { get; set; }
    }

    class PopularAdapter : BaseAdapter
    {
        private Android.Support.V4.App.Fragment _fragment;
        private List<Popular> _popular;

        public PopularAdapter(Android.Support.V4.App.Fragment fragment, List<Popular> popular)
        {
            _fragment = fragment;
            _popular = popular;
        }

        public override int Count
        {
            get
            {
                return _popular.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return _popular[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _fragment.LayoutInflater.Inflate(Resource.Layout.popular_list_view_dataTemplate, parent, false);
            var txtName = view.FindViewById<TextView>(Resource.Id.popName);
            var txtVote = view.FindViewById<TextView>(Resource.Id.popVote);

            txtName.Text = _popular[position].Name;
            txtVote.Text = _popular[position].Vote.ToString();

            return view;
        }
    }
}



