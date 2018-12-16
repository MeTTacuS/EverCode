using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WhatsThatDatabase.Models;

namespace WhatsThatDatabase.Contex
{
    public class DatabaseContext : DbContext
    {
        //public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<LoginInfo> LoginInfo { get; set; }
        public DbSet<SeenUser> SeenUsers { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<WhoSawWho> WhoSawWho { get; set; }
    }
}