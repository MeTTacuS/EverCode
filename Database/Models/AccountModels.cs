using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WhosThatDatabase.Models
{
    public class RegistrationModel
    {
        [Required]
        public string username;
        [Required]
        public string password;
        [Required]
        public string repeatedPassword;
    }

}