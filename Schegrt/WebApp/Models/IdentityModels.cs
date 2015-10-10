using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApp.Models.Field;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? Type { get; set; }
        
        public int GeneralUserId { get; set; }

        public virtual IList<UserFOI> Interests { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        public DbSet<GeneralUser> GeneralUsers { get; set; }
        public DbSet<FieldOfInterest> Fields { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}