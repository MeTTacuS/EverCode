using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhosThatDatabase.Models
{
    public class LoginInfo
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserInfo
    {
        [Key]
        public int ID { get; set; }
        public int Points { get; set; }
        public byte[] ImageByteArray { get; set; }
    }

    public class WhoSawWho
    {
        public int WhoSawID { get; set; }
        public virtual List<SeenUser> SeenUser { get; set; }
    }

    public class SeenUser
    {
        public DateTime DateTime { get; set; }

        public int WhoSawID { get; set; }
        public virtual WhoSawWho WhoSawWho { get; set; }
    }
}