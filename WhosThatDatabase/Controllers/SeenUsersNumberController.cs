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
    public class SeenUsersNumberController : ApiController
    {
        // GET: api/SeenUsersNumber
        public int Get(int id)
        {
            int no = 0;

            using (DatabaseContext db = new DatabaseContext())
            {
                var user = db.WhoSawWho.SingleOrDefault(a => a.WhoSawID == id);
                if (user != null)
                {
                    no = (from o in db.SeenUsers
                          where o.WhoSawID == user.WhoSawID
                          select o).Count();
                    return no;
                }
                return no;
            }
        }
    }
}
