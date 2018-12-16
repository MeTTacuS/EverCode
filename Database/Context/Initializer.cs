using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhosThatDatabase.Models;
using System.Data.Entity;

namespace WhosThatDatabase.Context
{
    public class Initializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);

            UserInfo userinfo = new UserInfo
            {
                ID = 2
            };
            context.UserInfo.Add(userinfo);
            context.SaveChanges();
        }
    }
}