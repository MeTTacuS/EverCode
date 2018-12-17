using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhosThatDatabase.Models
{
    public class RegistrationModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] ImageByteArray { get; set; }
    }
}W