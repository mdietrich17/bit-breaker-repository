using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimplySeniors.DAL;
using SimplySeniors.Models;
using SimplySeniors.Models.ViewModel;
using Microsoft.AspNet.Identity;
using System.Globalization;
using SimplySeniors.Attributes;
using System.Web.Script.Serialization;

namespace SimplySeniors.Controllers
{
    public class UserHomePageController : Controller
    {
        // GET: UserHomePage
        [CustomAuthorize]
        public ActionResult HomePage()
        {
            // Get the ASP.NET Identity Id of the currently authorized user
            string id = User.Identity.GetUserId();
            ProfileContext profiledb = new ProfileContext();
            PostContext db = new PostContext();
            // Get all profile info for current logged in user where the ASPNET ID = profile ID
            Profile profile = profiledb.Profiles.Where(u => u.USERID == id).FirstOrDefault();
            List<Post> postlist = db.Posts.Where(x => x.ProfileID == profile.ID).ToList();
            UserHomeViewModel viewModel = new UserHomeViewModel(profile, postlist);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

    }
}