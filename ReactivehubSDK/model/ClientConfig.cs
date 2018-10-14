using System;

namespace ReactivehubSDK.model
{
    public class ClientConfig
    {
        /// <summary>
        /// Client Key of reactivehub.io Account
        /// </summary>
        public String ClientKey { get; }

        /// <summary>
        /// Client Secret of reactivehub.io Account
        /// </summary>
        public String ClientSecret { get; }

        public ClientConfig(string clientKey, string clientSecret)
        {
            ClientKey = clientKey;
            ClientSecret = clientSecret;
        }
    }
}