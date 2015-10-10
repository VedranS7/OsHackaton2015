using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field
{
	public class ProjectFOI
	{
		public int Id { get; set; }
		public virtual Project Project { get; set; }
		public virtual FieldOfInterest Foi { get; set; }
		public int Level { get; set; }
	}
}