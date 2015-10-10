using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProvidersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Providers
        public ActionResult Index()
        {
            return View(db.Users.OfType<ProviderUser>().ToList());
        }

        // GET: Providers/Details/5
        public ActionResult Details(string id)
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

        // GET: Providers/Edit/5
        public ActionResult Edit(string id)
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
