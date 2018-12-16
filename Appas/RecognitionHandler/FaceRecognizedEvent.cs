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

namespace Appas.RecognitionHandler
{
    public class FaceRecognizedEvent
    {
        public delegate void FaceRecognizedEventHandler(object source, FaceRecognizedEventArgs e);
    }

    public class FaceRecognizedEventArgs
    {
        public int userID;
        public FaceRecognizedEventArgs(int userID)
        {
            this.userID = userID;
        }
    }

    public class FaceAddedEvent
    {
        public delegate void FaceAddedEventHandler(object source, FaceAddedEventArgs e);
    }

    public class FaceAddedEventArgs
    {
        public int userID;
        public FaceAddedEventArgs(int userID)
        {
            this.userID = userID;
        }
    }
}