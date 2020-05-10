using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using SimplySeniors.DAL;
using SimplySeniors.Models;

namespace SimplySeniors.Controllers
{
    public class ChatController : Controller
    {
        private ProfileContext db = new ProfileContext();

        // GET: Chat
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();  // Getting currently logged in user. 
            IQueryable<Profile> profileList = db.Profiles.Where(u => u.USERID != id); // Getting all profiles that can be chatted with, excluding the current signed in user. 
            //var currentUser = db.Profiles.Where(u => u.ID.ToString() == id);
            //var usersProfile = db.Profiles.FirstOrDefault(u => u.USERID == id);
     
     
            return View(profileList.ToList()); // Display all profiles( minus currently logged in user) for chat, phase 2, make click able. 
        }


        [HttpPost]   // FUNCTION TO OBTAIN the current user for message feature. 
        public JsonResult GetCurrentUser()
        {
            var id = User.Identity.GetUserId();
            var usersProfile = db.Profiles.FirstOrDefault(u => u.USERID == id);
            return Json(usersProfile, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetAllProfiles()
        {
            //var listOfAllProfiles = profile.Profiles.Select(u => u.FIRSTNAME).ToList();
            //return Json(listOfAllProfiles, JsonRequestBehavior.AllowGet);
            var members = db.Profiles.Select(r => r.FIRSTNAME).Distinct();
            //return Json(members, JsonRequestBehavior.AllowGet);
            return new ContentResult
            {
                // serialize C# object "commits" to JSON using Newtonsoft.Json.JsonConvert
                Content = JsonConvert.SerializeObject(members),
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };



        }

        [HttpPost]
        public JsonResult GetSpecificMember(int id)
        {
            var person = db.Profiles.FirstOrDefault(u => u.ID == id);
            return Json(person, JsonRequestBehavior.AllowGet);
        }




    }





}

//// GET: Chat/Details/5
    //public ActionResult Details(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    Profile profile = db.Profiles.Find(id);
    //    if (profile == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(profile);
    //}

    //// GET: Chat/Create
    //public ActionResult Create()
    //{
    //    return View();
    //}

    //// POST: Chat/Create
    //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create([Bind(Include = "ID,USERID,FIRSTNAME,LASTNAME,BIRTHDAY,CITY,STATE,VETSTATUS,PROFILECREATED,OCCUPATION,FAMILY,BIO")] Profile profile)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        db.Profiles.Add(profile);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    return View(profile);
    //}

    //// GET: Chat/Edit/5
    //public ActionResult Edit(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    Profile profile = db.Profiles.Find(id);
    //    if (profile == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(profile);
    //}

    //// POST: Chat/Edit/5
    //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit([Bind(Include = "ID,USERID,FIRSTNAME,LASTNAME,BIRTHDAY,CITY,STATE,VETSTATUS,PROFILECREATED,OCCUPATION,FAMILY,BIO")] Profile profile)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        db.Entry(profile).State = EntityState.Modified;
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }
    //    return View(profile);
    //}

    //// GET: Chat/Delete/5
    //public ActionResult Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    Profile profile = db.Profiles.Find(id);
    //    if (profile == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(profile);
    //}

    //// POST: Chat/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public ActionResult DeleteConfirmed(int id)
    //{
    //    Profile profile = db.Profiles.Find(id);
    //    db.Profiles.Remove(profile);
    //    db.SaveChanges();
    //    return RedirectToAction("Index");
   
//}
