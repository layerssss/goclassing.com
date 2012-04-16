using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ispJs;
using System.IO;
namespace Goclassing.com
{
    public class Global : System.Web.HttpApplication
    {
        public static Dictionary<string, ISocialProvider> SocialProviders = new Dictionary<string, ISocialProvider>();
        protected void Application_Start(object sender, EventArgs e)
        {
            SocialProviders.Add("facebook", new FacebookProvider());

            WebApplication.RegisterActions("Goclassing.com", typeof(Auth));


            WebApplication.RegisterRenderer("Default.htm.isp.js", new Default());

            WebApplication.RegisterSubPage("user.isp.js");
            WebApplication.RegisterRenderer("user.isp.js", new user());

            WebApplication.RegisterActions("Goclassing.com", typeof(Error));
            WebApplication.RegisterActions("Goclassing.com", typeof(Course));

            WebApplication.RegisterRenderer("users.isp.js", new users());
            WebApplication.RegisterSubPage("users.isp.js");

            WebApplication.RegisterRenderer("courses.isp.js", new courses());
            WebApplication.RegisterSubPage("courses.isp.js");


            WebApplication.RegisterSubPage("tag.isp.js");
            WebApplication.RegisterRenderer("tag.isp.js", new tag());

            WebApplication.RegisterRenderer("tags.isp.js", new tags());


            WebApplication.RegisterSubPage("course.isp.js");
            WebApplication.RegisterRenderer("course.isp.js",new course());


            WebApplication.RegisterSubPage("classroom.isp.js");
            WebApplication.RegisterRenderer("classroom.isp.js", new classroom());

            WebApplication.RegisterSubPage("file.isp.js");
            WebApplication.RegisterRenderer("file.isp.js", new file());




            WebApplication.ErrorPath = "/Error";
            WebApplication.HandleStart(Server);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {

            var path = Request.Path;
            var exts = new[] { "js", "css", "jpeg", "jpg", "gif", "png", "swf" };
            var ext = "";
            try
            {
                ext = path.Substring(path.LastIndexOf('.') + 1);
            }
            catch { }
            if (!(path.Contains('.')&& exts.Contains(ext)))
            {
                Response.ContentType = "text/html";
            }
        }
        static DateTime version = DateTime.Today;
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (DateTime.Today != version)
            {
                WebApplication.SafeDelete("Default.htm");
                WebApplication.SafeDelete("", ".classroom");
                WebApplication.SafeDelete("", ".course");
                WebApplication.SafeDelete("", ".courses");
                WebApplication.SafeDelete("", ".file");
                WebApplication.SafeDelete("", ".tag");
                WebApplication.SafeDelete("", ".tags");
                WebApplication.SafeDelete("", ".user");
                WebApplication.SafeDelete("", ".users");
                version = DateTime.Today;
            }
            WebApplication.HandleBeginRequest();

        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {

        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            WebApplication.HandleEnd();
        }
        public static string ConnectinoString
        {
            get
            {
                return "Server=dev.xunnlv.com;Database=goclassing_com";
            }
        }
        public static string HttpRoot
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["HttpRoot"];
            }
        }
        public static bool IsLocal
        {
            get
            {
                return HttpRoot.ToLower().StartsWith("http://t.");
            }
        }
        public static goclassingcom Entities
        {
            get
            {
                return new goclassingcom(new MySql.Data.MySqlClient.MySqlConnection(Global.ConnectinoString));
            }
        }

        public static string CookieDomain
        {
            get
            {
                return "goclassing.com";
            }
        }

    }
}