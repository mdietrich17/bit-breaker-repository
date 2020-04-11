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
    public class FollowListsController : Controller
    {
        private FollowContext db = new FollowContext();
        private ProfileContext db1 = new ProfileContext();

        // GET: FollowLists
        public ActionResult Index()
        {

            return View(db.FollowLists.ToList());
        }

        // GET: FollowLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FollowList followList = db.FollowLists.Find(id);
            if (followList == null)
            {
                return HttpNotFound();
            }
            return View(followList);
        }

        // GET: FollowLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FollowLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FollowedUserID,TimeFollowed")] FollowList followList)
        {

            string id = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == id).FirstOrDefault();
            followList.UserID = profile.ID;
            followList.TimeFollowed = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.FollowLists.Add(followList);
                db.SaveChanges();
                return RedirectToAction("HomePage", "UserHomePage");
            }

            return View(followList);
        }

        // GET: FollowLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FollowList followList = db.FollowLists.Find(id);
            if (followList == null)
            {
                return HttpNotFound();
            }
            return View(followList);
        }

        // POST: FollowLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,FollowedUserID,TimeFollowed")] FollowList followList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(followList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(followList);
        }

        // GET: FollowLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FollowList followList = db.FollowLists.Find(id);
            if (followList == null)
            {
                return HttpNotFound();
            }
            return View(followList);
        }

        // POST: FollowLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FollowList followList = db.FollowLists.Find(id);
            db.FollowLists.Remove(followList);
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
