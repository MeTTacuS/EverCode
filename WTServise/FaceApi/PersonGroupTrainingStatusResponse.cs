using System;

namespace PersonManager.FaceApi
{
   enum PersonGroupTrainingStatus
   {
      notstarted,
      running,
      succeeded,
      failed
   }

   class PersonGroupTrainingStatusResponse
   {
      public string Status { get; set; }
      public string CreatedDateTime { get; set; }
      public string LastActionDateTime { get; set; }
      public string Message { get; set; }

      public DateTime GetCreatedDateTime()
      {
         DateTime.TryParse(CreatedDateTime, out DateTime dt);
         return dt;
      }

      public DateTime GetLastActionDateTime()
      {
         DateTime.TryParse(LastActionDateTime, out DateTime dt);
         return dt;
      }

      public PersonGroupTrainingStatus GetPersonGroupTrainingStatus()
      {
         Enum.TryParse(Status, true, out PersonGroupTrainingStatus status);
         return status;
      }
   }
}
