using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimplySeniors
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
          routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "HomePage",
            url: "Home",
            defaults: new { controller = "UserHomePage", action = "HomePage", id = UrlParameter.Optional }
            );

            routes.MapRoute(    // Used for logging in with custom user name for chat function. 
                name: "Login",
                url: "login",
                defaults: new { controller = "Auth", action = "Login" }
            );

            routes.MapRoute(    //  Custom routing for the chat function
                name: "ChatRoom",
                url: "chat",
                defaults: new { controller = "Chat", action = "Index" }
            );

            routes.MapRoute(
                name: "Comment",
                url: "Profiles/Details/{id}",
                defaults: new { controller = "Profiles", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

               routes.MapRoute(
               name: "EventInfo",
               url: "api/{action}/{id}",
               defaults: new { controller = "Events", action = "ExternalEvents", id = UrlParameter.Optional }
           );

               routes.MapRoute(
               name: "SearchforEvents",
               url: "api/{action}/{id}",
               defaults: new { controller = "Events", action = "SearchExternalEvents", id = UrlParameter.Optional }
           );

        }
    }
}
