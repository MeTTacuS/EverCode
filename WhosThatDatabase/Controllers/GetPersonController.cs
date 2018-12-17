using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhosThatDatabase.Models;
using WhosThatDatabase.Context;

namespace WhosThatDatabase.Controllers
{
    public class GetPersonController : ApiController
    {
        // GET: api/GetPerson
        public string Get(int id) // Returns a persons username by his ID
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var username = db.LoginInfos.First(a => a.ID == id);
                if (username != null)
                    return username.Username;
                else
                    return "aaaa";
            }
        }
    }
}
