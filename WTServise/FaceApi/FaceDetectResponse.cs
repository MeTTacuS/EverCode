namespace PersonManager.FaceApi
{
   class FaceDetectResponse
   {
      public string FaceId { get; set; }

      public Rectangle FaceRectangle { get; set; }

      public FaceLandmarks FaceLandmarks { get; set; }

      public FaceAttributes FaceAttributes { get; set; }
   }

   class Rectangle
   {
      public int Width { get; set; }
      public int Height { get; set; }
      public int Left { get; set; }
      public int Top { get; set; }
   }

   class Point
   {
      public double X { get; set; }
      public double Y { get; set; }
   }
}
