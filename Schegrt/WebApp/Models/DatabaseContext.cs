﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models.Field;

namespace WebApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<FieldOfInterest> Fields { get; set; }
        public DatabaseContext() : base("DefaultConnection") { }

		public System.Data.Entity.DbSet<WebApp.Models.Field.SkillLevel> SkillLevels { get; set; }
	}
}