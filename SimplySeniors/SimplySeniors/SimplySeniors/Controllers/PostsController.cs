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
using SimplySeniors.Attributes;
using System.Security;

namespace SimplySeniors.Controllers
{
    [CustomAuthorize]
    public class PostsController : Controller
    {
        private PostContext db = new PostContext();
        private ProfileContext db1 = new ProfileContext();
        private PostLikeContext db2 = new PostLikeContext();

        // GET: Posts
        public ActionResult Index()
        {

            string id = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == id).FirstOrDefault();
            int strid = profile.ID;
            return View(db.Posts.ToList().Where(x => x.ProfileID == strid));
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Body,Likes,PostDate")] Post post)
        {
            string id = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == id).FirstOrDefault();
            post.ProfileID = profile.ID;
            if (ModelState.IsValid)
            {
                post.Likes = 0;
                post.PostDate = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("MyProfile", "Profiles");
            }
            return View(post);
        }
        public ActionResult Like(int id)
        {
            string uid = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == uid).FirstOrDefault();
            PostLike like = db2.PostLikes.Where(x => x.PostID == id && x.ProfileID == profile.ID).FirstOrDefault();
            Post update = db.Posts.ToList().Find(x => x.ID == id);
            if (like == null) {
                PostLike newlike = new PostLike();
                update.Likes += 1;
                newlike.PostID = id;
                newlike.Liked = true;
                newlike.ProfileID = profile.ID;
                db.SaveChanges();
                db2.PostLikes.Add(newlike);
                db2.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if(like.Liked == false)
            {
                update.Likes += 1;
                like.Liked = true;
                db.SaveChanges();
                db2.Entry(like).State = EntityState.Modified;
                db2.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if(like.Liked == true) {
                update.Likes -= 1;
                like.Liked = false;
                db.SaveChanges();
                db2.Entry(like).State = EntityState.Modified;
                db2.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
            
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            string userid = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == userid).FirstOrDefault();
            if (post.ProfileID != profile.ID) { 
            throw new SecurityException("Unauthorized access! You can only edit your own posts!");
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Body,ProfileID")] Post post)
        {
            string id = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyProfile", "Profiles");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            string userid = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == userid).FirstOrDefault();
            if (post.ProfileID != profile.ID)
            {
                throw new SecurityException("Unauthorized access! You can only delete your own posts!");
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("MyProfile", "Profiles");
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
