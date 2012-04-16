using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public partial class user
{
    public string providerFriendlyName
    {
        get
        {
            return Goclassing.com.Global.SocialProviders[this.authProvider].FriendlyName;
        }
    }
    public string providerProfileLink
    {
        get
        {
            return Goclassing.com.Global.SocialProviders[this.authProvider].GetProfileLink(this.authId);
        }
    }
    public string avatarUrlLarge
    {
        get
        {
            return Goclassing.com.Global.SocialProviders[this.authProvider].GetAvatarUrlLarge(this.authId);
        }
    }

}