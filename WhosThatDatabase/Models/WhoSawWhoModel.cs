using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhosThatDatabase.Models
{
    public class WhoSawWhoModel
    {
        public int WhoSawID { get; set; }
        public int WasSeenID { get; set; }
        public DateTime Date { get; set; }
    }
}
