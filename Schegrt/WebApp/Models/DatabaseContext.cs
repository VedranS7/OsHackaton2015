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
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<GeneralUser> Users { get; set; }
        public DbSet<FieldOfInterest> Fields { get; set; }
		public DbSet<Category> Categories {	get; set; }
        public DbSet<UserFOI> UserFOIs { get; set; }
		public DbSet<Project> Projects { get; set; }

		public System.Data.Entity.DbSet<WebApp.Models.Field.ProjectFOI> ProjectFOIs { get; set; }
	}
}