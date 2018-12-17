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
        public bool Post(RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return false;
            using (DatabaseContext db = new DatabaseContext())
            {
                LoginInfo newLogin = new LoginInfo();
                newLogin.Password = model.Password;
                newLogin.Username = model.Username;

                UserInfo newUser = new UserInfo();
                newUser.Points = 0;
                newUser.ImageByteArray = model.ImageByteArray;
                newUser.RecognitionID = model.RecognitionID;

                db.LoginInfos.Add(newLogin);
                db.SaveChanges();

                newUser.ID = newLogin.ID;
                db.UserInfos.Add(newUser);
                db.SaveChanges();
                return true;
            }
        }
    }
}
