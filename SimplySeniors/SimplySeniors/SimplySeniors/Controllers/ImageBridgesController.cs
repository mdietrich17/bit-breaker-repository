using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimplySeniors;
using SimplySeniors.DAL;

namespace SimplySeniors.Controllers
{
    public class ImageBridgesController : Controller
    {
        private ImagesContext db = new ImagesContext();

        // GET: ImageBridges
        public ActionResult Index()
        {
            var imageBridges = db.ImageBridges.Include(i => i.Image);
            return View(imageBridges.ToList());
        }

        // GET: ImageBridges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ImageBridge imageBridge = db.ImageBridges.Find(id);
            if (imageBridge == null)
            {
                return HttpNotFound();
            }

            return View(imageBridge);
        }

        // GET: ImageBridges/Create
        public ActionResult Create()
        {
            ViewBag.ImageID = new SelectList(db.Images, "ID", "NAME");
            return View();
        }

        // POST: ImageBridges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProfileID,ImageID")]
            ImageBridge imageBridge)
        {
            if (ModelState.IsValid)
            {
                db.ImageBridges.Add(imageBridge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImageID = new SelectList(db.Images, "ID", "NAME", imageBridge.ImageID);
            return View(imageBridge);
        }

        // GET: ImageBridges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ImageBridge imageBridge = db.ImageBridges.Find(id);
            if (imageBridge == null)
            {
                return HttpNotFound();
            }

            ViewBag.ImageID = new SelectList(db.Images, "ID", "NAME", imageBridge.ImageID);
            return View(imageBridge);
        }

        // POST: ImageBridges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProfileID,ImageID")]
            ImageBridge imageBridge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageBridge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImageID = new SelectList(db.Images, "ID", "NAME", imageBridge.ImageID);
            return View(imageBridge);
        }

        // GET: ImageBridges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ImageBridge imageBridge = db.ImageBridges.Find(id);
            if (imageBridge == null)
            {
                return HttpNotFound();
            }

            return View(imageBridge);
        }

        // POST: ImageBridges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageBridge imageBridge = db.ImageBridges.Find(id);
            db.ImageBridges.Remove(imageBridge);
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
