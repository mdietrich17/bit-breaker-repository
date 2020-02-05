using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using ThrowawayProject.Models;
using ThrowawayProject.Controllers;


namespace ThrowawayProject.Controllers
{
    
    public class ProfileController : Controller
    {
        // GET: Profile


        [Authorize]
        public ActionResult settings()
        {
            
                if(User.Identity.IsAuthenticated)
                {
                
                string id = HttpContext.User.Identity.GetUserId();
         
                
                
                return View();
                }
  
            else
            {
                return RedirectToAction("Index", "Login");
            }


        }
    }
}