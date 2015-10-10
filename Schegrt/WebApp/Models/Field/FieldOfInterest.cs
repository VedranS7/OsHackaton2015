using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field
{

	public class FieldOfInterest
	{
		public int Id { get; set; }
		public string name
		{
			get; set;
		}
		public SkillLevel skill
		{
			get; set;
		}
	}
}