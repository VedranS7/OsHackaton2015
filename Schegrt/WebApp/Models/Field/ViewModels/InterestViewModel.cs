using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field.ViewModels
{
    public class InterestViewModel
    {
        [Display(Name = "Field of interest")]
        public int FOIId { get; set; }
        [Display(Name = "Skill level")]
        public int Level { get; set; }
    }
}