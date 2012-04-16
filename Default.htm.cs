using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goclassing.com
{
    public class Default:ispJs.IISPRenderer,ispJs.IISPAC
    {
        public void Page_Load(Dictionary<string, object> locals)
        {
            var d=Global.Entities;
            locals.Add("courses", d.courses.OrderByDescending(tc => tc.createTime).Take(24).ToArray());
        }

        #region IDisposable 成员

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IISPAC 成员

        public void Page_Read(string subPage)
        {
            if (Auth.Username == null)
            {
            }
        }

        #endregion
    }
}