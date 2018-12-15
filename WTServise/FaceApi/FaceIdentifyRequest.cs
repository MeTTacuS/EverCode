using System.Collections.Generic;

namespace PersonManager.FaceApi
{
    class FaceIdentifyRequest
    {
      public List<string> FaceIds { get; set;}
      public string PersonGroupId { get; set; }
      public int? MaxNumOfCandidatesReturned { get; set; }
      public double? ConfidenceThreshold { get; set; }
   }
}
