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
    public class FieldsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Fields
        public ActionResult Index()
        {
            return View(db.Fields.ToList());
        }

        // GET: Fields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOfInterest fieldOfInterest = db.Fields.Find(id);
            if (fieldOfInterest == null)
            {
                return HttpNotFound();
            }
            return View(fieldOfInterest);
        }

        // GET: Fields/Create
        public ActionResult Create()
        {
			ViewBag.Categories = db.Categories.Select(x=> new SelectListItem {Value = x.Id.ToString(), Text = x.Name}).ToList();
            return View();
        }

        // POST: Fields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId")] FieldOfInterestViewModel fieldOfInterest)
        {
			FieldOfInterest foi = new FieldOfInterest { Name = fieldOfInterest.Name, Category = db.Categories.Where(x => x.Id == fieldOfInterest.CategoryId).FirstOrDefault() };

            if (ModelState.IsValid)
            {
                db.Fields.Add(foi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fieldOfInterest);
        }

        // GET: Fields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOfInterest fieldOfInterest = db.Fields.Find(id);
            if (fieldOfInterest == null)
            {
                return HttpNotFound();
            }
            return View(fieldOfInterest);
        }

        // POST: Fields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] FieldOfInterest fieldOfInterest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fieldOfInterest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fieldOfInterest);
        }

        // GET: Fields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOfInterest fieldOfInterest = db.Fields.Find(id);
            if (fieldOfInterest == null)
            {
                return HttpNotFound();
            }
            return View(fieldOfInterest);
        }

        // POST: Fields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FieldOfInterest fieldOfInterest = db.Fields.Find(id);
            db.Fields.Remove(fieldOfInterest);
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
