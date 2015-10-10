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
        public DbSet<UserFOI> UserFOIs { get; set; }

        public int Type { get; set; }
        public DatabaseContext() : base("DefaultConnection") { }

		public DbSet<Project> Projects { get; set; }
	}
}