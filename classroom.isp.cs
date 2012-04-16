using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goclassing.com
{
    public class classroom:ispJs.IISPAC,ispJs.IISPRenderer
    {
        #region IISPAC 成员

        public void Page_Read(string subPage)
        {
            var d = Global.Entities;
            if (!Logic.ValidateJoin(d, subPage))
            {
                throw (new ispJs.AccessDeniedException("You need to join this course in order to view this content."));
            }
        }

        #endregion

        #region IISPRenderer 成员

        public void Page_Load(Dictionary<string, object> locals)
        {
            var id = (string)locals["$subPage"];
            var d=Global.Entities;
            var c = d.courses.First(tc => tc.id == id);
            locals["c"] = c;
            var types = new Dictionary<string, global::doc[]>();
            foreach (var t in c.types.OrderBy(tt=>tt.sort))
            {
                types[t.id.ToString()] = t.doc.OrderBy(td => td.sort).ToArray();
            }
            locals["types"] = types;
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