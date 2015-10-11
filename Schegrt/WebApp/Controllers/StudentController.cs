using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Field;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Student
        public ActionResult Index()
        {
            StudentUser studentUser = db.Users.OfType<StudentUser>().FirstOrDefault(u => u.Email == User.Identity.Name);
			return View(studentUser);
			//st<StudentUser> studentUserList = new List<StudentUser>();
			//var dbUsers = db.Users.ToList();
			//foreach (GeneralUser user in dbUsers)
			//{
			//	studentUserList.Add(user as StudentUser);
			//}
			//return View(studentUserList);
}

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentUser studentUser = db.Users.Find(id) as StudentUser;
			if (studentUser == null)
            {
                return HttpNotFound();
            }
            return View(studentUser);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Location,Name,Surname")] StudentUser studentUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(studentUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentUser);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentUser studentUser = db.Users.Find(id) as StudentUser;
			if (studentUser == null)
            {
                return HttpNotFound();
            }
            return View(studentUser);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Location,Name,Surname")] StudentUser studentUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentUser);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentUser studentUser = db.Users.Find(id) as StudentUser;
			if (studentUser == null)
            {
                return HttpNotFound();
            }
            return View(studentUser);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentUser studentUser = db.Users.Find(id) as StudentUser;
			db.Users.Remove(studentUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Search(String location, int[] interestIds)
        {
            List<StudentUser> initialResult = db.Users.OfType<StudentUser>().ToList();
            if (location != null) initialResult = initialResult.Where(pu => pu.Location == location).ToList();
            if (interestIds != null && interestIds.Count() > 0)
            {
                initialResult = initialResult.Where(pu => hasInterest(interestIds, pu.Interests)).ToList();
            }
            return View(initialResult);
        }

        public bool hasInterest(int[] expectedInterestIds, IList<UserFOI> interests)
        {
            foreach (int interestId in expectedInterestIds)
            {
                if (interests.Select(x => x.Foi.Id).Contains(interestId)) return true;
            }

            return false;
        }

    }
}
