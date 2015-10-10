using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field.ViewModels
{
	public class FieldOfInterestViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int CategoryId { get; set; }
	}
}