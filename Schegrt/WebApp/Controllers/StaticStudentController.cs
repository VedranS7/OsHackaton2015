using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Matchers;

namespace WebApp.Controllers
{
    public class StaticStudentController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: StaticStudent
        public ActionResult Index()
        {
            StudentUser studentUser = db.Users.OfType<StudentUser>().FirstOrDefault(su => su.Email == User.Identity.Name);
            
            if (studentUser != null)
            {
                List<GeneralUser> otherTypeOfUsers = studentUser is StudentUser ? db.Users.OfType<ProviderUser>().Cast<GeneralUser>().ToList() : db.Users.OfType<StudentUser>().Cast<GeneralUser>().ToList();
                ViewBag.Recommendations = new ProviderMatcher(studentUser).GetMatchingProvider(otherTypeOfUsers);
            }

            return View(studentUser);
        }

        // GET: StaticStudent/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: StaticStudent/Edit/5
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
