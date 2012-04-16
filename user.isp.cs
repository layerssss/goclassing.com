using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goclassing.com
{
    public class user:ispJs.IISPRenderer
    {
        public void Page_Load(Dictionary<string, object> locals)
        {
            var d = Global.Entities;
            var uname=(string)locals["$subPage"];
            var u = d.users.First(tu => tu.username == uname);
            locals["u"] = u;
            locals["learnings"] = u.joining.Where(tj=>tj.aprooved).Select(tj => tj.course).ToArray();
            locals["teachings"] = u.courses.ToArray();
            locals["activities"] = u.activities.OrderByDescending(ta => ta.time).Take(8);
        }

        #region IDisposable 成员

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}