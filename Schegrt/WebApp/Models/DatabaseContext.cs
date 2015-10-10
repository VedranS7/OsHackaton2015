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
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<FieldOfInterest> Fields { get; set; }
        public DatabaseContext() : base("DefaultConnection") { }
    }
}