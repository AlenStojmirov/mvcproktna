using ProektnaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProektnaMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
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

        [Authorize]
        public ActionResult MyAccount()
        {
            var user = User.Identity.Name;
            var tipster = db.Tipsters.Where(t => t.UserName == user).First();
            var picks = db.Picks.Where(p => p.Tipster.Id == tipster.Id);
            return View(picks);
        }
    }
}