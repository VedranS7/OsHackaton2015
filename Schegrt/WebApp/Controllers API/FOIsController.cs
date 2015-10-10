using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Models.Field;

namespace WebApp.Controllers_API
{
    public class FOIsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        public class FoiDto
        {
            public int Id;
            public String Name;
        }

        // GET: api/foi
        public IQueryable<FoiDto> GetFields()
        {
            IQueryable<FoiDto> result = db.Fields.Select(f => new FoiDto() { Id = f.Id, Name = f.Name });
            return result;
        }
    }
}