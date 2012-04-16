using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goclassing.com
{
    public class file:ispJs.IISPAC,ispJs.IISPRenderer
    {
        #region IISPAC 成员

        public void Page_Read(string subPage)
        {

            var fid = Convert.ToInt32(subPage);
            var d = Global.Entities;
            var f = d.doc.First(tf => tf.id == fid);
            if (!Logic.ValidateJoin(d, f.type.courseid))
            {
                throw (new ispJs.AccessDeniedException("Oops, page not found..."));
            }
        }

        #endregion

        #region IISPRenderer 成员

        public void Page_Load(Dictionary<string, object> locals)
        {
            var fid = Convert.ToInt32((string)locals["$subPage"]);
            var d = Global.Entities;
            var f = d.doc.First(tf => tf.id == fid);
            locals["c"] = f.type.course;
            locals["f"] = f;
            locals["replies"] = f.replies.ToArray();
            locals["chapters"] = Logic.ParseChapters(f.content);

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