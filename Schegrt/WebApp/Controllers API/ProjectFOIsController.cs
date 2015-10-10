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

namespace WebApp.Controllers_API
{
    public class ProjectFOIsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ProjectFOIs
        public ActionResult Index()
        {
            return View(db.ProjectFOIs.ToList());
        }

        // GET: ProjectFOIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectFOI projectFOI = db.ProjectFOIs.Find(id);
            if (projectFOI == null)
            {
                return HttpNotFound();
            }
            return View(projectFOI);
        }

        // GET: ProjectFOIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectFOIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Level")] ProjectFOI projectFOI)
        {
            if (ModelState.IsValid)
            {
                db.ProjectFOIs.Add(projectFOI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectFOI);
        }

        // GET: ProjectFOIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectFOI projectFOI = db.ProjectFOIs.Find(id);
            if (projectFOI == null)
            {
                return HttpNotFound();
            }
            return View(projectFOI);
        }

        // POST: ProjectFOIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Level")] ProjectFOI projectFOI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectFOI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectFOI);
        }

        // GET: ProjectFOIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectFOI projectFOI = db.ProjectFOIs.Find(id);
            if (projectFOI == null)
            {
                return HttpNotFound();
            }
            return View(projectFOI);
        }

        // POST: ProjectFOIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectFOI projectFOI = db.ProjectFOIs.Find(id);
            db.ProjectFOIs.Remove(projectFOI);
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
