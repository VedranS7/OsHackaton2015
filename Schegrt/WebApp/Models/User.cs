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
        public String Id { get; set; }
        public String Email { get; set; }
        public String Location { get; set; }
    }

    public enum UserType
    {
        Student = 1,
        Provider = 2
    }

    public class StudentUser : GeneralUser
    {
        public String Name { get; set; }
        public String Surname { get; set; }
    }

    public class ProviderUser : GeneralUser
    {
        public String CompanyName { get; set; }
        public String Description { get; set; }
        public String URL { get; set; }
    }
}