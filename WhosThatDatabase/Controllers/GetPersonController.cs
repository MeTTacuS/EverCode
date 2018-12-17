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
        public string Get(int id)//REIKIA SUSIRASTI REIKALINGA ZMOGU DATABASE
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var username = db.LoginInfos.First(a => a.ID == id);
                return username.Username;
            }
        }
    }
}
