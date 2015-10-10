using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Models.Field
{
    public class SkillLevelsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: SkillLevels
        public ActionResult Index()
        {
            return View(db.SkillLevels.ToList());
        }

        // GET: SkillLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillLevel skillLevel = db.SkillLevels.Find(id);
            if (skillLevel == null)
            {
                return HttpNotFound();
            }
            return View(skillLevel);
        }

        // GET: SkillLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ResourceKey")] SkillLevel skillLevel)
        {
            if (ModelState.IsValid)
            {
                db.SkillLevels.Add(skillLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skillLevel);
        }

        // GET: SkillLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillLevel skillLevel = db.SkillLevels.Find(id);
            if (skillLevel == null)
            {
                return HttpNotFound();
            }
            return View(skillLevel);
        }

        // POST: SkillLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ResourceKey")] SkillLevel skillLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skillLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skillLevel);
        }

        // GET: SkillLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillLevel skillLevel = db.SkillLevels.Find(id);
            if (skillLevel == null)
            {
                return HttpNotFound();
            }
            return View(skillLevel);
        }

        // POST: SkillLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkillLevel skillLevel = db.SkillLevels.Find(id);
            db.SkillLevels.Remove(skillLevel);
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
