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


