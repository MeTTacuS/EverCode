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
    public class WhoSawWhoController : ApiController // Requires WhoSawID, WhoWasSeenID, Date
    {
        // POST: api/WhoSawWho
        public bool Post([FromBody]WhoSawWhoModel model)
        {
            if (!ModelState.IsValid)
                return false;

            using (DatabaseContext db = new DatabaseContext())
            {

                WhoSawWho user = new WhoSawWho();
                user.WhoSawID = model.WhoSawID;
                user.WasSeenID = model.WasSeenID;
                user.DateTime = model.Date;
                db.SaveChanges();
                return true;
            }
        }
    }
}
