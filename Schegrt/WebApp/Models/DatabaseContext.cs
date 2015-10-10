using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models.Field;

namespace WebApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<StudentUser> Students { get; set; }
        public DbSet<ProviderUser> Providers { get; set; }
        public DbSet<FieldOfInterest> Fields { get; set; }
        public int Type { get; set; }
        public DatabaseContext() : base("DefaultConnection") { }
    }
}