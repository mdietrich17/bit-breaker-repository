using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimplySeniors;

namespace SimplySeniors.Attributes
{

public class AuthorizeAdminOrOwnerOfPostAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // The user is not authenticated
                return false;
            }

            var user = httpContext.User;

            var rd = httpContext.Request.RequestContext.RouteData;
            var id = rd.Values["id"] as string;
            if (string.IsNullOrEmpty(id))
            {
                // No id was specified => we do not allow access
                return false;
            }

            return IsOwnerOfPost(user.Identity.Name, id);
        }

    }
}