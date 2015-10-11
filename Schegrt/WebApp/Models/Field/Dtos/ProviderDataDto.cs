using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field.Dtos
{
    public class ProviderDataDto : UserDataDto
    {
        public String Email { get; set; }
        public String CompanyName { get; set; }
        public String Description { get; set; }
        public String URL { get; set; }

        public ProviderDataDto() { }

        public ProviderDataDto(ProviderUser user)
        {
            Email = user.Email;
            Location = user.Location;
            CompanyName = user.CompanyName;
            Description = user.Description;
            URL = user.URL;
        }
    }
}