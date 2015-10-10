using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Field
{

    public class FieldOfInterest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Skills { get; set; }
        public Category Category { get; set; }
    }
}