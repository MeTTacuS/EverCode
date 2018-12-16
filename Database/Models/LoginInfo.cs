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
        public int ID;
        public string Username { get; set; }
        public string Password { get; set; }
    }
}