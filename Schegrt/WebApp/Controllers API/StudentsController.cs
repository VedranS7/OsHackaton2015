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
using WebApp.Models.Field.Dtos;

namespace WebApp.Controllers_API
{
    public class StudentsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Providers
        public IQueryable<StudentUser> GetUsers()
        {
            return db.Users.OfType<StudentUser>();
        }

        // GET: api/Providers/5
        [ResponseType(typeof(StudentDataDto))]
        public IHttpActionResult GetStudentUser(int id)
        {
            StudentUser studentUser = db.Users.FirstOrDefault(u => u.Id == id) as StudentUser;
            if (studentUser == null)
            {
                return NotFound();
            }

            return Ok(new StudentDataDto(studentUser));
        }

        [ResponseType(typeof(StudentDataDto))]
        public IHttpActionResult PutProviderUser(StudentDataDto data)
        {
			StudentUser user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name) as StudentUser;
            if (user == null)
            {
                return NotFound();
            }

            user.Name = data.Name;
			user.Surname = data.Surname;
            user.Location = data.Location;

            db.Entry(user).State = EntityState.Modified;
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

        private bool ProviderUserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}