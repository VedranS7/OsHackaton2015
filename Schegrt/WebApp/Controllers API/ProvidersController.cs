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

namespace WebApp.Controllers_API
{
    public class ProvidersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Providers
        public IQueryable<ProviderUser> GetUsers()
        {
            return db.Users.OfType<ProviderUser>();
        }

        // GET: api/Providers/5
        [ResponseType(typeof(ProviderUser))]
        public IHttpActionResult GetProviderUser(string id)
        {
            ProviderUser providerUser = db.Users.Find(id) as ProviderUser;
            if (providerUser == null)
            {
                return NotFound();
            }

            return Ok(providerUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProviderUserExists(string id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}