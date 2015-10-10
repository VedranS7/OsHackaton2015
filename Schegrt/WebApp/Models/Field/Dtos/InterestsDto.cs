using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field.Dtos
{
    public class InterestsDto
    {
        public int Id;
        public String Name;
        public int Level;

        public InterestsDto() { }
        public InterestsDto(UserFOI interest)
        {
            Id = interest.Id;
            Name = interest.Foi.Name;
            Level = interest.Level;
        }
    }
}