using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.FaceApi
{
   public class PersonResponse
   {
      public string PersonId { get; set; }
      public string Name { get; set; }
      public string UserData { get; set; }
      public List<string> PersistedFaceIds { get; set; }
   }
}
