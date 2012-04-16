﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goclassing.com
{
    public class Auth
    {
        [ispJs.Action]
        public void OAuthValidate(string code, string provider, bool remember)
        {

            string username, aId, aToken, name, avatarUrl, gender;
            DateTime aTokenExp;
            try
            {
                Global.SocialProviders[provider].Validate(code, remember, out username, out aId, out aToken, out aTokenExp, out name, out avatarUrl, out gender);
            }
            catch {
                return;
            }
            var d = Global.Entities;
            var user = d.users.FirstOrDefault(tu => tu.authProvider == provider && tu.authId == aId);
            if (user == null)
            {
                user = new global::user()
                {
                    authId = aId,
                    authProvider = provider,
                    avatarUrl = "",
                    gender = "",
                    name = "",
                    username = ""
                };
                d.users.InsertOnSubmit(user);
                d.SubmitChanges();
                secret s = new secret()
                {
                    userid = user.id,
                    authToken = "",
                    authTokenExpire = DateTime.Now,
                    logon=0
                };
                d.secrets.InsertOnSubmit(s);
                d.SubmitChanges();
            }

            user.username = username;
            GetSecret(user.id,d).logon = new Random().Next();
            GetSecret(user.id, d).authToken = aToken;
            GetSecret(user.id, d).authTokenExpire = aTokenExp;

            user.name = name;
            user.avatarUrl = avatarUrl;
            user.gender = gender;
            d.SubmitChanges();
            var ckuid = new HttpCookie("gcuid", user.username.ToString())
            {
                Domain = Global.CookieDomain
            };
            var ckuhash = new HttpCookie("gchash", user.username + GetSecret(user.id,d).logon.ToString())
            {
                Domain = Global.CookieDomain
            };
            if (remember)
            {
                ckuid.Expires = DateTime.Now.AddMonths(1);
                ckuhash.Expires = DateTime.Now.AddMonths(1);
            }
            HttpContext.Current.Response.Cookies.Add(ckuid);
            HttpContext.Current.Response.Cookies.Add(ckuhash);
            HttpContext.Current.Response.Redirect("/OAuthFinished.htm");
        }
        [ispJs.Action]
        public void Logout()
        {
            var d = Global.Entities;
            var uid = Username;
            if (uid == null)
            {
                throw (new Exception("You're not logon."));
            }
            var user = d.users.First(tu => tu.username == uid);
            GetSecret(user.id,d).logon = new Random().Next();
            d.SubmitChanges();

        }
        [ispJs.Action]
        public void GetLoginUrl(bool remember, string provider, out string url)
        {
            url = Global.SocialProviders[provider].GetLoginUrl(remember);
        }
        public static string Username
        {
            get
            {
                var d=Global.Entities;
                var ckin = HttpContext.Current.Request.Cookies;
                var ckuid = ckin["gcuid"];
                var ckuhash = ckin["gchash"];
                if (ckuid == null || ckuhash == null)
                {
                    return null;
                }
                var uid = ckuid.Value;
                var uhash = ckuhash.Value;
                var u = d.users.FirstOrDefault(tu => tu.username == uid);
                if (u == null)
                {

                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("gcuid") { Expires = DateTime.Now.AddDays(-1), Domain = Global.CookieDomain });
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("gchash") { Expires = DateTime.Now.AddDays(-1), Domain = Global.CookieDomain });
                    return null;
                }
                if (uhash != uid + GetSecret(u.id,d).logon.ToString())
                {
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("gcuid") { Expires = DateTime.Now.AddDays(-1), Domain = Global.CookieDomain });
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("gchash") { Expires = DateTime.Now.AddDays(-1), Domain = Global.CookieDomain });
                    return null;
                }
                return uid;
            }
        }
        public static string GetUsername()
        {
            var uname = Username;
            if (uname == null)
            {
                throw (new ispJs.AccessDeniedException("You need to sign in first."));
            }
            return uname;
        }
        public static secret GetSecret(int userId,goclassingcom d)
        {
            return d.secrets.First(ts => ts.userid == userId);
        }

        [ispJs.Action]
        public void GetStatus(out global::user me, out string message)
        {
            var d = Global.Entities;
            var c = ispJs.WebApplication.Request.Cookies["errormsg"];
            if (c == null)
            {
                message = null;
            }
            else
            {
                message = c.Value;
                ispJs.WebApplication.Response.Cookies.Add(new HttpCookie("errormsg") { 
                    Expires = DateTime.Now.AddDays(-1),
                    Domain=Global.CookieDomain,
                    Path = "/"
                });
            }
            var uid = Username;
            if (uid == null)
            {
                me = null;
                return;
            }

            var u = d.users.First(tu => tu.username == uid);
            me = u;
        }
        [ispJs.Action]
        public void OAuthNotify(string provider)
        {
            Global.SocialProviders[provider].Notify();
        }
    }
}