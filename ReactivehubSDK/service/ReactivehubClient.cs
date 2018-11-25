using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ReactivehubSDK.model;

namespace ReactivehubSDK.service
{
    public class ReactivehubClient
    {
        private ClientConfig clientConfig;

        /// <summary>
        /// Initialize the client
        /// </summary>
        /// <param name="teamName"></param>
        /// <param name="clientKey"></param>
        /// <param name="clientSecret"></param>
        /// <returns>Task<HttpResponseMessage></returns>
        public ReactivehubClient(String teamName, String clientKey, String ClientSecret)
        {
            if (String.IsNullOrEmpty(clientKey.Trim())
                || String.IsNullOrEmpty(clientSecret.Trim())
                || String.IsNullOrEmpty(teamName.Trim()))
            {
                throw new ArgumentException("Parameter empty or null is not valid to initialize the client");
            }
            this.clientConfig = new ClientConfig(clientKey, clientSecret, teamName);
        }

        /// <summary>
        /// Call to Event in Reactivehub Platform
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="payload"></param>
        /// <returns>Task<HttpResponseMessage></returns>
        public async Task<HttpResponseMessage> PublishEvent(String eventName, String payload)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            httpClient.DefaultRequestHeaders.Add("client_key", clientConfig.ClientKey);
            httpClient.DefaultRequestHeaders.Add("client_secret", clientConfig.ClientSecret);

            var URL = $"https://{clientConfig.Namespace}.reactivehub.io/event/{eventName}";

            Console.WriteLine($"Calling HTTP Resource: Method: POST / URL: {URL} with Payload: {payload}");

            var stringContent = new StringContent(payload, Encoding.UTF8,"application/json");

            return await httpClient.PostAsync(URL, stringContent);
        }

    }
}