using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;
namespace Goclassing.com
{
    public class FacebookProvider:ISocialProvider
    {

        System.Net.WebClient c = new System.Net.WebClient();
        string getStr(string format, params object[] args)
        {
            var str = "Network error:";
            for (var i = 0; i < 1; i++)
            {
                try
                {
                    return c.DownloadString(ap + string.Format(format, args));
                }
                catch(Exception ex)
                {
                    try
                    {
                        var sr = new System.IO.StreamReader((ex as WebException).Response.GetResponseStream());
                        str += sr.ReadToEnd();
                        sr.Close();
                    }
                    catch { }
                    //str += ex.ToString();
                }
            }
            throw (new System.Net.WebException(str));
        }
        static string ap = "https://graph.facebook.com/";
        public static string AppID = "304082169654964";
        static string appSecret = "9173d2adafe50bc05d180d8002b86c57";
        static string appAuthToken = "304082169654964|siEX3jX8T99pYaIX2IKHMMGTipg";
        static string VERIFY_TOKEN = "poiuytrewq";

        #region ISocialProvider 成员

        public void Validate(string code, bool remember, out string id, out string authId, out string authToken,out DateTime authTokenExpre, out string name, out string avatarUrl, out string gender)
        {
            authToken = getStr(
                "oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}",
                AppID,
                HttpUtility.UrlEncode(Global.HttpRoot + "Auth/OAuthValidate?provider=facebook&remember=" + remember.ToString().ToLower()),
                appSecret,
                code).Split('&')[0].Split('=')[1];
            var me = JObject.Parse(getStr(
                "me?access_token={0}",
                authToken));
            id = (string)me["id"] + ".facebook";
            authId = (string)me["id"];
            name = (string)me["name"];
            gender = (string)me["gender"];
            avatarUrl = ap + authId + "/picture";
            authTokenExpre = DateTime.Now.AddDays(30);
        }

        public void Notify()
        {
            var context = HttpContext.Current;
            var request = context.Request; 
            if (request.HttpMethod == "GET" &&
                request.Params["hub.mode"] == "subscribe" 
                &&request.Params["hub.verify_token"] == VERIFY_TOKEN)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(request.Params["hub.challenge"]);
                context.Response.End();
            }
            else if (request.HttpMethod == "POST")
            {
                var reader = new System.IO.StreamReader(request.InputStream);
                var o = JObject.Parse(reader.ReadToEnd());
                reader.Close();
                var fql = "SELECT name,username from user WHERE uid in "
                    + '(' + o["entry"].Select(m => (string)m["uid"]).Aggregate("", (str, num) => str + ',' + num, str => str) + ')';
                o = JObject.Parse(getStr("fql?q={0}&access_token={1}",
                    HttpUtility.UrlEncode(fql),
                    appAuthToken));
                foreach (var user in o["data"])
                {
                    var uid=((string)user["uid"]);
                    var u = Global.Entities.users.First(tu => tu.authProvider == "facebook" && tu.authId == uid);
                    u.name = (string)user["name"];
                }


            }
        }
        #endregion

        #region ISocialProvider 成员


        public string GetLoginUrl(bool remember)
        {
            return "https://www.facebook.com/dialog/oauth?client_id=" + AppID + "&redirect_uri="
                + HttpUtility.UrlEncode(
                Global.HttpRoot + "Auth/OAuthValidate?provider=facebook&remember=" + remember.ToString().ToLower()
                )
                + "&scope=email";
        }

        #endregion

        #region ISocialProvider 成员


        public string FriendlyName
        {
            get { return "Facebook"; }
        }

        public string GetProfileLink(string authId)
        {
            return "https://www.facebook.com/" + authId;
        }

        #endregion

        #region ISocialProvider 成员


        public string GetAvatarUrlLarge(string authId)
        {
            return "https://graph.facebook.com/" + authId + "/picture?type=large";
        }

        #endregion
    }
}