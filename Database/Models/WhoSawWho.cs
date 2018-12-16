using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhosThatDatabase.Models
{
    public class WhoSawWho
    {
        [Key]
        public int WhoSawID { get; set; }
        public int WasSeenID { get; set; }

        public List<SeenUser> SeenUser { get; set; }
    }
}