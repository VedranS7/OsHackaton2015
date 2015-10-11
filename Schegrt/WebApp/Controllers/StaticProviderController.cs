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
    public class StaticProviderController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: StaticProvider
        public ActionResult Index()
        {
            ProviderUser providerUser = db.Users.OfType<ProviderUser>().FirstOrDefault(u => u.Email == User.Identity.Name);

            if (providerUser != null)
            {
                List<GeneralUser> otherTypeOfUsers = providerUser is StudentUser ? db.Users.OfType<ProviderUser>().Cast<GeneralUser>().ToList() : db.Users.OfType<StudentUser>().Cast<GeneralUser>().ToList();
                ViewBag.Recommendations = new ProviderMatcher(providerUser).GetMatchingProvider(otherTypeOfUsers);
            }

            return View(providerUser);
        }

        // GET: StaticProvider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderUser providerUser = db.Users.FirstOrDefault(x => x.Id == id) as ProviderUser;
            if (providerUser == null)
            {
                return HttpNotFound();
            }
            return View(providerUser);
        }

        // GET: StaticProvider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderUser providerUser = db.Users.Find(id) as ProviderUser;
            if (providerUser == null)
            {
                return HttpNotFound();
            }
            return View(providerUser);
        }

        // POST: StaticProvider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Location,CompanyName,Description,URL")] ProviderUser providerUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providerUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(providerUser);
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
