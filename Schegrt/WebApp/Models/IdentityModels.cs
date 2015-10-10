using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApp.Models
{
    public class StudentUser : IdentityUser
    { 
        public string Location { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<StudentUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ProviderUser : IdentityUser
    {
        public string Location { get; set; }
        public string CompanyName { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ProviderUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<StudentUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}