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
    public class RaceResultsController : Controller
    {
        private AthleteContext db = new AthleteContext();

        // GET: RaceResults
        public ActionResult Index()
        {
            var raceResults = db.RaceResults.Include(r => r.Athlete).Include(r => r.Meet);
            return View(raceResults.ToList());
        }
    }
}
