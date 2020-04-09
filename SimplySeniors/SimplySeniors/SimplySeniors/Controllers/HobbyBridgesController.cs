using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SimplySeniors.DAL;
using SimplySeniors.Models;

namespace SimplySeniors.Controllers
{
    public class HobbyBridgesController : Controller
    {
        private HobbiesContext db = new HobbiesContext();
        private ProfileContext db1 = new ProfileContext();

        // GET: HobbyBridges
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == id).FirstOrDefault();
            var hobbyBridges = db.HobbyBridges.Where(h => h.ProfileID == profile.ID);
            return View(hobbyBridges.ToList());
        }

        // GET: HobbyBridges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HobbyBridge hobbyBridge = db.HobbyBridges.Find(id);
            if (hobbyBridge == null)
            {
                return HttpNotFound();
            }
            return View(hobbyBridge);
        }

        // GET: HobbyBridges/Create
        public ActionResult Create()
        {
            ViewBag.HobbiesID = new SelectList(db.Hobbies, "ID", "NAME");
            return View();
        }

        // POST: HobbyBridges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HobbiesID,ProfileID")] HobbyBridge hobbyBridge)
        {
            string id = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == id).FirstOrDefault();
            hobbyBridge.ProfileID = profile.ID;
            if (ModelState.IsValid)
            {
     
                db.HobbyBridges.Add(hobbyBridge);
                db.SaveChanges();
                return RedirectToAction("Details", "Profiles", new { id = profile.ID });
            }

            ViewBag.HobbiesID = new SelectList(db.Hobbies, "ID", "NAME", hobbyBridge.HobbiesID);
            return View(hobbyBridge);
        }

        // GET: HobbyBridges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HobbyBridge hobbyBridge = db.HobbyBridges.Find(id);
            if (hobbyBridge == null)
            {
                return HttpNotFound();
            }
            ViewBag.HobbiesID = new SelectList(db.Hobbies, "ID", "NAME", hobbyBridge.HobbiesID);
            return View(hobbyBridge);
        }

        // POST: HobbyBridges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HobbiesID,ProfileID")] HobbyBridge hobbyBridge)
        {
            string id = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == id).FirstOrDefault();
            hobbyBridge.ProfileID = profile.ID;
            if (ModelState.IsValid)
            {
                db.Entry(hobbyBridge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HobbiesID = new SelectList(db.Hobbies, "ID", "NAME", hobbyBridge.HobbiesID);
            return View(hobbyBridge);
        }

        // GET: HobbyBridges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HobbyBridge hobbyBridge = db.HobbyBridges.Find(id);
            if (hobbyBridge == null)
            {
                return HttpNotFound();
            }
            return View(hobbyBridge);
        }

        // POST: HobbyBridges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HobbyBridge hobbyBridge = db.HobbyBridges.Find(id);
            db.HobbyBridges.Remove(hobbyBridge);
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
