namespace PersonManager.FaceApi
{
   class FaceApiError
   {
      public string Code { get; set; }
      public string Message { get; set; }
   }

   class FaceApiErrorResponse
   {
      public FaceApiError Error { get; set; }
   }
}
