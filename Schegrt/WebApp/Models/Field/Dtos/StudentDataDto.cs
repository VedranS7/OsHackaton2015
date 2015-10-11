using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field.Dtos
{
    public class StudentDataDto : UserDataDto
    {
        public String Name { get; set; }
		public String Surname { get; set; }
        public String Email { get; set; }

        public StudentDataDto() { }

        public StudentDataDto(StudentUser user)
        {
            Location = user.Location;
            Name = user.Name;
			Surname = user.Surname;
            Email = user.Email;
        }
    }
}