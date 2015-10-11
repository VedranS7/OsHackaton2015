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
using WebApp.Models.Field.ViewModels;

namespace WebApp.Controllers
{
    public class InterestsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Interests
        public ActionResult Index()
        {
            GeneralUser user = db.Users.Include(i => i.Interests).FirstOrDefault(u => u.Email == User.Identity.Name);
            IList<UserFOI> result = user != null ? user.Interests : new List<UserFOI>();
            return View(result);
        }

        // GET: Interests/Create
        public ActionResult Create()
        {
            ViewBag.FieldsOfInterests = db.Fields.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
            return View();
        }

        // POST: Interests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InterestViewModel interest)
        {
            if (ModelState.IsValid)
            {
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
                return RedirectToAction("Index", user is StudentUser ? "student" : "providers", null);
            }

            return View(interest);
        }

        // GET: Interests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFOI userFOI = db.UserFOIs.Find(id);
            if (userFOI == null)
            {
                return HttpNotFound();
            }
            return View(userFOI);
        }

        // POST: Interests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserFOI userFOI = db.UserFOIs.Find(id);
            db.UserFOIs.Remove(userFOI);
            db.SaveChanges();
            return RedirectToAction("Index", db.Users.FirstOrDefault(x => x.Email == User.Identity.Name) is StudentUser ? "student" : "providers", null);
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
