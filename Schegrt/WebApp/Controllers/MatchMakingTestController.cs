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
    public class MatchMakingTestController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: MatchMakingTest
        public ActionResult Index(int? id)
        {
			if (id > 0)
			{
				GeneralUser initiator = db.Users.Where(st => st.Id == id).OfType<StudentUser>().FirstOrDefault();

				List<GeneralUser> listaFabrika = db.Users.OfType<ProviderUser>().Cast<GeneralUser>().ToList();

				ProviderMatcher matcher = new ProviderMatcher(initiator);
				List<GeneralUser> sortedList = matcher.GetMatchingProvider(listaFabrika);

				return View(sortedList.ToList());
			}
			 return HttpNotFound();
		}
    }
}
