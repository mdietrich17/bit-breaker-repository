using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimplySeniors.Controllers
{
    public class AuthController : Controller
    { // AUTH CONTROLLER PLANNED TO BE USED FOR CUSTOM LOGIN FOR CHAT FEATURE IN FUTURE SPRINT. 
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
    }
}