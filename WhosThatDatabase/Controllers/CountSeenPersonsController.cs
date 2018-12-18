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
    public class CountSeenPersonsController : ApiController
    {
        // GET: api/CountSeenPersons
        public int Get(int id)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                if (db.WhoSawWho.First(a => a.WhoSawID == id) == null)
                    return 0;
                else
                    return db.WhoSawWho.Where(a => a.WhoSawID == id).Count();
            }
        }
    }
}
