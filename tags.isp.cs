using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goclassing.com
{
    public class tags:ispJs.IISPRenderer
    {
        #region IISPRenderer 成员

        public void Page_Load(Dictionary<string, object> locals)
        {
            var d = Global.Entities;
            var tags = new Dictionary<string, int>();
            foreach (var t in d.tags.GroupBy(tt => tt.value))
            {
                tags[t.Key] = t.Count();
            }
            locals["tags"] = tags;
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}