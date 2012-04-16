using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public partial class doc
{
    
        public int commmentCount
        {
            get
            {
                return this.replies.Count();
            }
        }
        public string timeString
        {
            get
            {
                var t = DateTime.Now - this.time;
                var d=(int)t.TotalDays;
                if (d >= 356)
                {
                    var y = d / 356;
                    return y == 1 ? "1 year ago" : y + " years ago";
                }
                if (d >= 30)
                {
                    var y = d / 30;
                    return y == 1 ? "1 month ago" : y + " months ago";
                }
                if (d >= 7)
                {
                    var y = d / 7;
                    return y == 1 ? "1 week ago" : y + " weeks ago";
                }
                if (d >= 2)
                {
                    var y = d;
                    return y == 1 ? "1 day ago" : y + " days ago";
                }
                var ltime = this.time.AddHours(3);
                if (t.TotalDays == 1)
                {
                    return "yesterday " + ltime.ToShortTimeString();
                }
                return "today " + ltime.ToShortTimeString();
            }
        }
        public user[] paticipated
        {
            get
            {
                return this.replies.Select(tr => tr.user).Distinct().ToArray();
            }
        }
}