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
    public class UpvoteController : ApiController
    {
        // PUT: api/Upvote
        public bool Put(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = db.UserInfos.SingleOrDefault(a => a.ID == id);
                if (result != null)
                {
                    result.Points += 1;
                    db.SaveChanges();
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        // GET: api/Upvote
        public int Get(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = db.UserInfos.First(a => a.ID == id);
                return result.Points;
            }
        }
    }
}
