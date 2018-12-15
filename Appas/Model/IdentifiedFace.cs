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

namespace Appas.Model
{
    class IdentifiedFace
    {
        public string faceId { get; set; }
        public List<Candidate> candidates;
    }

    public class Candidate
    {
        public string personId;
        public decimal confidence;
    }
}