using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goclassing.com
{
    public class Logic
    {
        public static Chapter[] ParseChapters(string content)
        {
            var cs = new List<Chapter>();
            var f = new ispJs.Utility.StringFetcher(content);
            var tmp = new Chapter();
            var str = "";
            while ((str = f.Fetch("[t]", false)) != null)
            {
                f.Position += 3;
                tmp.content += HttpUtility.HtmlEncode(str).Replace("\n", "<br/>");

                cs.Add(tmp);
                tmp = new Chapter();


                tmp.title = f.Fetch("[t]", false);
                f.Position += 3;
            }
            tmp.content += HttpUtility.HtmlEncode(f.Left).Replace("\n","<br/>");
            cs.Add(tmp);
            foreach (var c in cs)
            {
                parseImages(parseLinks(c));
            }
            return cs.ToArray();
        }
        static Chapter parseLinks(Chapter c)
        {
            var f = new ispJs.Utility.StringFetcher(c.content);
            c.content = "";
            var str = "";
            while ((str = f.Fetch("[l]", false)) != null)
            {
                f.Position += 3;
                c.content += str;


                var url = f.Fetch("[l]", false);
                c.content += "<a href=\"" + url + "\" target=\"_blank\">" + url + "</a>";
                f.Position += 3;
            }
            c.content += f.Left;
            return c;
        }
        static Chapter parseImages(Chapter c)
        {
            var f = new ispJs.Utility.StringFetcher(c.content);
            c.content = "";
            var str = "";
            while ((str = f.Fetch("[i]", false)) != null)
            {
                f.Position += 3;
                c.content += str;


                var url = f.Fetch("[i]", false);
                c.content += "<a target=\"_blank\" data-fancybox-group=\"fancybox\" ref=\"fancybox\" class=\"fancybox thumbnail\" style=\"display:inline-block;\" href=\"" + url + "\" target=\"_blank\"><img style=\"height:150px;\" src=\"" + url + "\" /></a>";

                f.Position += 3;
                while (f.Left[0] =='\r' || f.Left[0] == '\n')
                {
                    f.Position++;
                }
                while (f.Left.StartsWith("<br/>[i]"))
                {
                    f.Position += 5;
                }
            }
            c.content += f.Left;
            return c;
        }
        public static bool ValidateJoin(goclassingcom d, string cid)
        {
                var c = d.courses.First(tc => tc.id == cid);
                if (c.pub)
                {
                    return true;
                }
                var uname = Auth.GetUsername();
                if (c.user.username == uname)
                {
                    return true;
                }
                if (d.joining.Any(tj => tj.userusername == uname && tj.aprooved))
                {
                    return true;
                }
                return false;

        }
        public class Chapter
        {
            public string title = null;
            public string safeTitle
            {
                get
                {
                    if (title == null)
                    {
                        return null;
                    }
                    var l = new List<char>();
                    foreach (var c in this.title)
                    {
                        if (char.IsLetter(c))
                        {
                            l.Add(c);
                        }
                    }
                    return new string(l.ToArray());
                }
            }
            public string content = "";
        }
    }
}