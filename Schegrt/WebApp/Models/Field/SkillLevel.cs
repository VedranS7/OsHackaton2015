using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field
{
	public class SkillLevel
	{
		[Key]
		public int Id { get; set; }
		public string ResourceKey { get; set; }
	}
}