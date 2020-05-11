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
using Newtonsoft.Json;

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


        [HttpPost]
        public ActionResult AjaxCreate(int userid)
        {
            FollowList followList = new FollowList();
            followList.FollowedUserID = userid;
            string id = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == id).FirstOrDefault();
            followList.UserID = profile.ID;
            followList.TimeFollowed = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.FollowLists.Add(followList);
                db.SaveChanges();
                return new ContentResult
                {
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8,
                    Content = JsonConvert.SerializeObject(id)

                };
            }
            return View(followList);
        }


            public ActionResult Follow(int id)
            {
                string uid = User.Identity.GetUserId();
                Profile currentUser = db1.Profiles.Where(x => x.USERID == uid).FirstOrDefault();
                Profile followie = db1.Profiles.Where(x => x.ID == id).FirstOrDefault();
                List<FollowList> followLists = new List<FollowList>();
                followLists = db.FollowLists.Where(x => x.UserID == currentUser.ID).ToList();
                if (currentUser.ID == followie.ID || followLists.Any(x => x.FollowedUserID == followie.ID))
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }

                FollowList followList = new FollowList();
                followList.UserID = currentUser.ID;
                followList.TimeFollowed = DateTime.Now;
                followList.FollowedUserID = followie.ID;

                if (ModelState.IsValid)
                {
                    db.FollowLists.Add(followList);
                    db.SaveChanges();
                    return Redirect(Request.UrlReferrer.ToString());
                }
                return Redirect(Request.UrlReferrer.ToString());
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
