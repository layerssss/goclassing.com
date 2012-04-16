using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goclassing.com
{
    public interface ISocialProvider
    {
        void Validate(
            string code,
            bool remember,
            out string id,
            out string authId,
            out string authToken,
            out DateTime authTokenExpre,
            out string name,
            out string avatarUrl,
            out string gender);
        void Notify();
        string GetLoginUrl(bool remember);
        string FriendlyName
        {
            get;
        }
        string GetProfileLink(string authId);
        string GetAvatarUrlLarge(string authId);
    }
}