using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhatsThatDatabase.Models
{
    public class UserInfo
    {
        [Key]
        public int ID { get; set; }
        public int Points { get; set; }
        public byte[] ImageByteArray { get; set; }
    }
    public class LoginInfo
    {
        [Key]
        public int ID;
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class WhoSawWho
    {
        [Key]
        public int WhoSawID { get; set; }
        public int WasSeenID { get; set; }

        public List<SeenUser> SeenUser { get; set; }
    }
    public class SeenUser
    {
        public string Date { get; set; }
        public string Time { get; set; }

        public int WasSeenID { get; set; }
        public WhoSawWho WhoSawWho { get; set; }
    }
}