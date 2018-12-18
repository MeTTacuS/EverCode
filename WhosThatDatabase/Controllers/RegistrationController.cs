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
    public class RegistrationController : ApiController
    {
        // POST: api/Registration
        public int Post([FromBody]RegistrationModel model)
        {
            if (!ModelState.IsValid || model == null)
                return -1;
            using (DatabaseContext db = new DatabaseContext())
            {
                LoginInfo newLogin = new LoginInfo();
                newLogin.Username = model.Username;
                UserInfo newUser = new UserInfo();
                newUser.Points = 0;
                newUser.ImageByteArray = null;

                db.LoginInfos.Add(newLogin);
                db.UserInfos.Add(newUser);
                db.SaveChanges();
                return newLogin.ID;
            }
        }
    }
}
