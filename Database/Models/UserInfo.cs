using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhosThatDatabase.Models
{
    public class UserInfo
    {
        [Key]
        public int ID { get; set; }
        public int Points { get; set; }
        public byte[] ImageByteArray { get; set; }
    }
}