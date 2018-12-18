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

namespace Appas.Request_Models
{
    public class HistoryModel
    {
        public string Username { get; set; }
        public string date { get; set; }
        public int points { get; set; }
        public int ID { get; set; }
    }
}