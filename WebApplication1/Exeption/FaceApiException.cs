using System;

namespace PersonManager
{
   class FaceApiException : Exception
   {
      public string Code { get; private set; }

      public FaceApiException(string code, string message) : base(message)
      {
         Code = code;
      }
   }
}
