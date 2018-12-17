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
    class DetectedFace
    {
        public string faceId { get; set; }
        public FaceReactangle faceRectangle { get; set; }
    }

    class FaceReactangle
    {
        public int top { get; set; }
        public int left { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}