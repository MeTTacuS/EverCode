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
    public class WhoSawWhoDefaultController : ApiController
    {
        // username - LoginInfo
        // id       - Betur
        // date     - SeenUser
        // points   - UserInfo

        // GET: api/WhoSawWhoDefault
        public List<HistoryModel> Get(int id) // Returns last 3 persons that were seen by the user, returns null if error
        {
            List<HistoryModel> model = new List<HistoryModel>();
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = db.WhoSawWho.First(a => a.WhoSawID == id);
                if (result != null)
                {
                    //var usersList = db.SeenUsers
                    //    .OrderByDescending(a => a.DateTime)
                    //    .Where(a => a.WhoSawID == result.WhoSawID)
                    //    .Take(3).ToList();

                    var list = (from l in db.UserInfos
                                join e in db.LoginInfos on l.ID equals e.ID
                                where e.ID == id
                                select new
                                {
                                    Username = e.Username,
                                    Date = result.DateTime,
                                    Points = l.Points,
                                    SeenID = result.WasSeenID
                                }).OrderByDescending(a => a.Date)
                                .Take(3).ToList();

                    foreach (var item in list)
                    {
                        HistoryModel temp = new HistoryModel();

                        temp.Date = item.Date;
                        temp.ID = item.SeenID;
                        temp.Points = item.Points;
                        temp.Username = item.Username;

                        model.Add(temp);
                    }

                    return model;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
