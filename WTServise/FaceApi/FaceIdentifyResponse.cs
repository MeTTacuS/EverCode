using System.Collections.Generic;

namespace PersonManager.FaceApi
{
   class FaceIdentifyCandidate
   {
      public string PersonId { get; set; }
      public double Confidence { get; set; }
   }

   class FaceIdentifyResponse
   {
      public string FaceId { get; set; }
      public List<FaceIdentifyCandidate> Candidates { get; set; }
   }
}
