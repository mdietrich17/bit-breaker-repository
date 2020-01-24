using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThrowawayProject.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult settings()
        {
            // if The user active user has an Id go to their profile
                /* 
                if(Session["UID"] != null)
                {
                    ViewBag.UserName = Session["UName"];
                    return View();
                }
                */
                
            // if the user doe snot have an active id direct them to the login page. 
            /*
            else
            {
                return RedirectToAction("Index", "Login");
            }
            */

            return View();
        }
    }
}