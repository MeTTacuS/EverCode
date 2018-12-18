using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WhosThatDatabase.Models;

namespace WhosThatDatabase.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<LoginInfo> LoginInfos { get; set; }
        public DbSet<WhoSawWho> WhoSawWho { get; set; }
    }
}