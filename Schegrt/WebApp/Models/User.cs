using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models.Field;

namespace WebApp.Models
{
    public abstract class GeneralUser
    {
        public Guid Id { get; set; }
        public String Email { get; set; }
        public String Location { get; set; }
        public int Type = 0;
		public List<UserFOI> interestList { get; set; }
    }

    public class StudentUser : GeneralUser
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public new int Type = 1;
    }

    public class ProviderUser : GeneralUser
    {
        public String CompanyName { get; set; }
        public String Description { get; set; }
        public String URL { get; set; }
        public new int Type = 2;
    }
}