using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThrowawayProject.DAL;
using ThrowawayProject.Models;

namespace ThrowawayProject.Controllers
{
    public class AthletesController : Controller
    {
        private AthleteContext db = new AthleteContext();

        // GET: Athletes
        public ActionResult Index()
        {
                 return View();
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            {
                IQueryable<Athlete> players = db.Athletes;
                ViewBag.Message = "Sorry no matching athlete has been found";

                if (!String.IsNullOrEmpty(searchString))
                {
                   players = players.Where(s => s.NAME.Contains(searchString));
                }

                return View(players.ToList());
            }
        }


        // GET: Detail results (uses a ViewModel in Model folder)
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Athlete player = db.Athletes.Find(id);
            if ( player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        public ActionResult List()
        {
            var athletes = db.Athletes;
            return View(athletes.ToList());
        }
    }
}
