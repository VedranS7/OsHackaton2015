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
            ProviderUser providerUser = db.Users.OfType<ProviderUser>().FirstOrDefault(u => u.Email == User.Identity.Name);
            return View(providerUser);
        }

        // GET: Providers/Details/5
        public ActionResult Details(int? id)
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
