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
    }
}


