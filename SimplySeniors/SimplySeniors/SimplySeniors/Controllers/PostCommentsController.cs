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
using SimplySeniors.Models.ViewModel;

namespace SimplySeniors.Controllers
{
    public class PostCommentsController : Controller
    {
        private CommentContext db = new CommentContext();
        private PostContext db1 = new PostContext();

        // GET: PostComments
        public ActionResult Index()
        {
            return View(db.PostComments.ToList());
        }

        // GET: PostComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostComment postComment = db.PostComments.Find(id);
            if (postComment == null)
            {
                return HttpNotFound();
            }
            return View(postComment);
        }
        public ActionResult Create()
        {
            return View();
        }

        // GET: PostComments/Create
        [HttpGet]
        public ActionResult Create(int id)
        {
            Post post = db1.Posts.Where(x => x.ID == id).FirstOrDefault();
            var model = new CCViewModel(post);
            return View(model);
        }

        // POST: PostComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int postID, string text)
        {
            string uid = User.Identity.GetUserId();
            Profile profile = db1.Profiles.Where(x => x.USERID == uid).FirstOrDefault();
            PostComment comment = new PostComment();
            comment.PostID = postID;
            comment.ProfileID = profile.ID;
            if (ModelState.IsValid)
            {
                comment.CommentDate = DateTime.Now;
                comment.Text = text;
                db.PostComments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Details", "Profiles", postID);
            }

            return View();
        }

        // GET: PostComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostComment postComment = db.PostComments.Find(id);
            if (postComment == null)
            {
                return HttpNotFound();
            }
            return View(postComment);
        }

        // POST: PostComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text,CommentDate,ProfileID,PostID")] PostComment postComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postComment);
        }

        // GET: PostComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostComment postComment = db.PostComments.Find(id);
            if (postComment == null)
            {
                return HttpNotFound();
            }
            return View(postComment);
        }

        // POST: PostComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostComment postComment = db.PostComments.Find(id);
            db.PostComments.Remove(postComment);
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
