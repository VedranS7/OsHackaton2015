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

        public ActionResult Search(String location, int[] interestIds)
        {
            IQueryable<ProviderUser> initialResult = db.Users.OfType<ProviderUser>();
            if (location != null) initialResult = initialResult.Where(pu => pu.Location == location);
            if(interestIds != null && interestIds.Count() > 0)
            {
                initialResult = initialResult.Where(pu => hasInterest(interestIds, pu.Interests));
            }
            return View(initialResult);
        }

        public bool hasInterest(int[] expectedInterestIds, IList<UserFOI> interests)
        {
            foreach(int interestId in expectedInterestIds)
            {
                if (interests.Select(x => x.Foi.Id).Contains(interestId)) return true;
            }

            return false;
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
