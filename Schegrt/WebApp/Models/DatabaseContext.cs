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
        public DbSet<GeneralUser> Users { get; set; }
        public DbSet<FieldOfInterest> Fields { get; set; }
		public DbSet<Category> Categories {	get; set; }
        public int Type { get; set; }
        public DatabaseContext() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneralUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<StudentUser>().Map<StudentUser>(s => { s.ToTable("AspNetUsers"); s.Requires("Type").HasValue((int)UserType.Student); });
            modelBuilder.Entity<ProviderUser>().Map<ProviderUser>(s => { s.ToTable("AspNetUsers"); s.Requires("Type").HasValue((int)UserType.Provider); });
        }

        public System.Data.Entity.DbSet<WebApp.Models.Field.UserFOI> UserFOIs { get; set; }
    }
}