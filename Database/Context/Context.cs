using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WhosThatDatabase.Models;

namespace WhosThatDatabase.Context
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection") { }

        public DbSet<LoginInfo> LoginInfo { get; set; }
        public DbSet<SeenUser> SeenUsers { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<WhoSawWho> WhoSawWho { get; set; }
    }
}