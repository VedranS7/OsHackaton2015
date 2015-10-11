using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field.Dtos
{
	public class RecomendedProjectDto
	{
		public int Id;
		public String Name;
		public String StartDate;
		public String EndDate;
		public String Interests;

		public RecomendedProjectDto() { }
		public RecomendedProjectDto(Project project)
		{
			Id = project.Id;
			Name = project.Name;
			StartDate = project.StartDate.ToShortDateString();
			EndDate = project.EndDate.ToShortDateString();
			Interests = String.Join(",", project.FoiList.Select(x => x.Foi.Name).ToList());
		}
	}
}