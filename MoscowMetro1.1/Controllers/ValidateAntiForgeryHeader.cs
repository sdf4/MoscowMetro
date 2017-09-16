using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

//http://www.ojdevelops.com/2016/01/using-antiforgerytokens-in-aspnet-mvc.html

namespace MoscowMetro1._1.Controllers
{
    public class ValidateAntiForgeryHeader : FilterAttribute, IAuthorizationFilter
    {
        private const string KEY_NAME = "__RequestVerificationToken";

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string clientToken = filterContext.RequestContext.HttpContext.Request.Headers.Get(KEY_NAME);
            if (clientToken == null) throw new HttpAntiForgeryException(String.Format("Header does not contain {0}", KEY_NAME));

            string serverToken = filterContext.HttpContext.Request.Cookies.Get(KEY_NAME).Value;
            if (serverToken == null) throw new HttpAntiForgeryException(String.Format("Cookies does not contain {0}", KEY_NAME));

            AntiForgery.Validate(serverToken, clientToken);
        }
    }
}