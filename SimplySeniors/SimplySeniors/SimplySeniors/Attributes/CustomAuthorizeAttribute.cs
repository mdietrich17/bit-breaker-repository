using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimplySeniors.DAL;
using SimplySeniors.Models;
using SimplySeniors.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace SimplySeniors.Attributes
{

public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }




        void IsUserAuthorized(AuthorizationContext filtercontext)
        {
            var user = filtercontext.HttpContext.User;
            var id = filtercontext.HttpContext.User.Identity.GetUserId(); //get user id
            if (id == null) // null value user is not logged in
            {
                //redirect to login page
                filtercontext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary{
                        { "controller", "Account" }, //account controller
                        { "action", "Login" }}); //action method
                return;
            }
            ProfileContext db = new ProfileContext(); //Access the Db at this point since this is the most overhead. 
            bool? profile = db.Profiles.Where(x => x.USERID == id).Select(x => x.PROFILECREATED).FirstOrDefault(); // get if user has created created a profile
            if (profile == null || profile == false) //if user hasn't made a profile redirect them
            {
                //redirect to profile creation
                filtercontext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"controller", "Profiles" },
                    {"action", "Create" }});
                return; //finish
            }
            else return; //user met all requirements let them go ahead
        }

    }
}