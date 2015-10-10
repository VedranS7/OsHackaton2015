using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field.Dtos
{
    public class RecommendedUserDto
    {
        public int Id;
        public String Name;
        public String Location;
        public String Interests;

        public RecommendedUserDto() { }
        public RecommendedUserDto(GeneralUser user)
        {
            Id = user.Id;
            Name = user.GetName();
            Location = user.Location;
            Interests = String.Join(",", user.Interests.Select(x => x.Foi.Name).ToList());
        }
    }
}