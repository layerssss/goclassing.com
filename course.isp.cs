using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goclassing.com
{
    public class course:ispJs.IISPRenderer
    {
        public void Page_Load(Dictionary<string, object> locals)
        {
            var cid = (string)locals["$subPage"];
            var d = Global.Entities;
            var c = d.courses.First(tc => tc.id == cid);
            locals["c"] = c;
            locals["chapters"] = Logic.ParseChapters(c.home);
            locals["joinings"] = c.joining.Where(tj => !tj.aprooved).Select(tj => tj.user).ToArray();
            locals["learnings"] = c.joining.Where(tj => tj.aprooved).Select(tj => tj.user).ToArray();
            
        }

        #region IDisposable 成员

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}