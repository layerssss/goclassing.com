using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goclassing.com
{
    public class courses:ispJs.IISPRenderer
    {
        #region IISPRenderer 成员

        public void Page_Load(Dictionary<string, object> locals)
        {

            var list = new List<string>();
            var d=Global.Entities;
            for (var c = 'A'; c <= 'Z'; c++)
            {
                list.Add(c.ToString());
            }
            locals.Add("alphabets", list);
            var ch = char.Parse((string)locals["$subPage"]).ToString();
            locals["courses"] = d.courses.Where(tc => tc.title.StartsWith(ch,StringComparison.OrdinalIgnoreCase)).ToArray();
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