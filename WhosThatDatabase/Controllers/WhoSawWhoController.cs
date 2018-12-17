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
                var result = db.WhoSawWho.SingleOrDefault(a => a.WhoSawID == model.WhoSawID);
                if (result == null) //If this user has never seen another person
                {
                    WhoSawWho userWhoSaw = new WhoSawWho();
                    userWhoSaw.WhoSawID = model.WhoSawID;

                    SeenUser user = new SeenUser();
                    user.DateTime = model.Date;
                    user.WhoSawID = userWhoSaw.WhoSawID;
                    user.WhoSawWho = userWhoSaw;
                    user.SeenUserID = model.WasSeenID;

                    userWhoSaw.SeenUser.Add(user);

                    db.WhoSawWho.Add(userWhoSaw);
                    db.SeenUsers.Add(user);
                    db.SaveChanges();
                    return true;
                }
                else // if this person has actually seen another person
                {
                    SeenUser user = new SeenUser();
                    user.DateTime = model.Date;
                    user.WhoSawID = result.WhoSawID;
                    user.WhoSawWho = result;
                    user.SeenUserID = model.WasSeenID;

                    result.SeenUser.Add(user);

                    db.SeenUsers.Add(user);
                    db.SaveChanges();
                    return true;
                }
            }
        }
    }
}
