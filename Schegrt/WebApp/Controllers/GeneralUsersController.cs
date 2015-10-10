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
    public class GeneralUsersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: GeneralUsers
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: GeneralUsers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralUser generalUser = db.Users.Find(id);
            if (generalUser == null)
            {
                return HttpNotFound();
            }
            return View(generalUser);
        }

        // GET: GeneralUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneralUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Location")] GeneralUser generalUser)
        {
            if (ModelState.IsValid)
            {
                generalUser.Id = Guid.NewGuid();
                db.Users.Add(generalUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(generalUser);
        }

        // GET: GeneralUsers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralUser generalUser = db.Users.Find(id);
            if (generalUser == null)
            {
                return HttpNotFound();
            }
            return View(generalUser);
        }

        // POST: GeneralUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Location")] GeneralUser generalUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generalUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(generalUser);
        }

        // GET: GeneralUsers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralUser generalUser = db.Users.Find(id);
            if (generalUser == null)
            {
                return HttpNotFound();
            }
            return View(generalUser);
        }

        // POST: GeneralUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GeneralUser generalUser = db.Users.Find(id);
            db.Users.Remove(generalUser);
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
    }
}
