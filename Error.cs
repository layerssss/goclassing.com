using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ispJs;
namespace Goclassing.com
{
    public class Error
    {

        [ispJs.Action]
        public void _(string message, string from)
        {
            WebApplication.Response.Cookies.Add(new HttpCookie("errormsg", message)
            {
                Domain = Global.CookieDomain,
                Path="/"
            });
            var refer = WebApplication.Request.UrlReferrer;
            WebApplication.Response.Redirect(from ?? (refer != null ? refer.AbsolutePath : "/"));
        }
    }
}