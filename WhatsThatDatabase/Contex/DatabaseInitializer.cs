using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsThatDatabase.Models;
using System.Data.Entity;

namespace WhatsThatDatabase.Contex
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
        }
    }
}