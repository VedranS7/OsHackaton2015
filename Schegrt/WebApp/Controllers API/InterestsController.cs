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
using WebApp.Models.Field.Dtos;
using WebApp.Models.Field.ViewModels;

namespace WebApp.Controllers_API
{
    public class InterestsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Interests/5
        public IQueryable<InterestsDto> GetUserInterests(int id)
        {
            return db.UserFOIs.Where(uf => uf.User.Id == id).Include(uf => uf.Foi).Select(uf => new InterestsDto()
            {
                Id = uf.Id,
                Name = uf.Foi.Name,
                Level = uf.Level
            });
        }

        // POST: api/Interests
        [ResponseType(typeof(InterestViewModel))]
        public IHttpActionResult AddUserInterest(InterestViewModel interest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            GeneralUser user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            FieldOfInterest foi = db.Fields.FirstOrDefault(f => f.Id == interest.FOIId);
            UserFOI userFOI = new UserFOI()
            {
                User = user,
                Foi = foi,
                Level = interest.Level
            };
            db.UserFOIs.Add(userFOI);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userFOI.Id }, userFOI);
        }

        // DELETE: api/Interests/5
        public IHttpActionResult DeleteUserInterest(int id)
        {
            UserFOI userFOI = db.UserFOIs.Find(id);
            if (userFOI == null)
            {
                return NotFound();
            }

            db.UserFOIs.Remove(userFOI);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}