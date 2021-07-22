namespace DestinyLoadoutBuilder.Services.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;

    public class Destiny2APIAuthorizationService : IDestiny2APIAuthorizationService
    {
        private readonly Guid _stateValue;

        public Destiny2APIAuthorizationService()
        {
            _stateValue = Guid.NewGuid();
        }

        /// <summary>
        /// Sends a GET request to Bungie.net's authorization URL to receive an Authorization token
        /// which is used to obtain authorization from their OAuth URL.
        /// </summary>
        /// <param name="httpClient">The injected httpclient instance</param>
        /// <returns></returns>
        public async Task AuthorizeWithBungie(HttpClient httpClient)
        {
            try
            {
                string authURI = string.Concat(httpClient.BaseAddress, "?client_id=37100&response_type=code&state=", _stateValue);
                var response = await httpClient.GetAsync(authURI);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error encountered: " + ex.Message);
            }
        }

        /// <summary>
        /// Sends a POST request to Bungie.net's OAuth token URL to authorize a restricted
        /// action by the user.
        /// </summary>
        /// <param name="uri">The current URI</param>
        /// <returns></returns>
        public async Task GetOauthTokenAsync(string uri)
        {
            //TODO: explore whether a brand new HttpClient instance is necessary
            using HttpClient client = new HttpClient();
            string authCode = GetAuthCodeFromURI(uri);
            KeyValuePair<string, string>[] keyValuePairs = new[]
            {
                new KeyValuePair<string, string>("Content-Type", "application/x-www-form-urlencoded"),
                new KeyValuePair<string, string>("Authorization", authCode)
            };
            FormUrlEncodedContent content = new FormUrlEncodedContent(keyValuePairs);

            await client.PostAsync("https://www.bungie.net/Platform/App/OAuth/token/", content);
        }

        /// <summary>
        /// Extracts the Authorization code from the current URI.
        /// </summary>
        /// <param name="uri">The current URI</param>
        /// <returns></returns>
        private string GetAuthCodeFromURI(string uri)
        {
            Uri theUri = new Uri(uri);
            string authCode = HttpUtility.ParseQueryString(theUri.Query).Get(0);
            string stateValue = GetStateValueFromURI(uri);
            return StateValueIsValid(stateValue) ? authCode : throw new InvalidOperationException("The state value did not match the server");
        }

        /// <summary>
        /// Extracts the state value from the current URI.
        /// </summary>
        /// <param name="uri">The current URI</param>
        /// <returns></returns>
        private string GetStateValueFromURI(string uri)
        {
            Uri theUri = new Uri(uri);
            string stateValue = HttpUtility.ParseQueryString(theUri.Query).Get(1);
            return stateValue;
        }

        /// <summary>
        /// Checks the state value in the URI to be sure it is the same one that was
        /// originally generated upon sending a request to the Authorization URL.
        /// </summary>
        /// <param name="state">The state value to check.</param>
        /// <returns></returns>
        private bool StateValueIsValid(string state)
        {
            if (Guid.Parse(state).Equals(_stateValue))
            {
                return true;
            }
            return false;
        }
    }

    public interface IDestiny2APIAuthorizationService
    {
        Task AuthorizeWithBungie(HttpClient httpclient);

        Task GetOauthTokenAsync(string uri);
    }
}