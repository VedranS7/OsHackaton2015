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
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<FieldOfInterest> Fields { get; set; }
        public DatabaseContext() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<ProviderUser>().ToTable("AspNetUsers");
        }
    }
}