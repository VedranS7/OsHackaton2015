using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();

            ViewBag.Providers = db.Users.OfType<StudentUser>().Count();
            ViewBag.Students = db.Users.OfType<ProviderUser>().Count();
            ViewBag.ProviderInterests = db.Users.OfType<StudentUser>().Sum(x => x.Interests.Count);
            ViewBag.ProviderProjects = db.Projects.Count();
            ViewBag.StudentInterests = db.Users.OfType<ProviderUser>().Sum(x => x.Interests.Count);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}