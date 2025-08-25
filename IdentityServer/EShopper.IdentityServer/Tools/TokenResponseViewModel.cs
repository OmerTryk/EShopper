using System;

namespace EShopper.IdentityServer.Tools
{
    public class TokenResponseViewModel
    {
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }

        public TokenResponseViewModel(string token, DateTime expireTime)
        {
            Token = token;
            ExpireTime = expireTime;
        }

    }
}
