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

        /// <summary>
        /// Client Secret of reactivehub.io Account
        /// </summary>
        public String Namespace { get; }

        public ClientConfig(String teamName, String clientKey, String clientSecret)
        {
            ClientKey = clientKey;
            ClientSecret = clientSecret;
            Namespace = teamName;
        }
    }
}