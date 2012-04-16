using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public partial class course
    {
        public string img
        {
            get
            {
                if (System.IO.File.Exists(ispJs.WebApplication.Server.MapPath("/img/course/" + this.id + ".jpg")))
                {
                    return "/img/course/" + this.id + ".jpg";
                }
                else
                {
                    return "/img/70x70.gif";
                }
            }
        }
        public string[] tag
        {
            get
            {
                return this.tags.Select(tt => tt.value).ToArray();
            }
        }
        public string tagString
        {
            get
            {
                return this.tag.Aggregate("[\"\"", (a, b) => a + ",\"" + b + "\"", (a) => a + "]");
            }
        }
    }