namespace DestinyLoadoutBuilder.Services.Authentication
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Destiny2APIAuthorizationService : IDestiny2APIAuthorizationService
    {
        private readonly Guid _stateValue;
        public Destiny2APIAuthorizationService() 
        {
            _stateValue = Guid.NewGuid();
        }
        public async Task AuthorizeWithBungie(HttpClient httpClient)
        {
            try
            {
                string authURI = string.Concat(httpClient.BaseAddress,"?client_id=37100&response_type=code&state=", _stateValue);
                var response = await httpClient.GetAsync(authURI);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error encountered: " + ex.Message);
            }
        }

        public async Task GetOauthTokenAsync(HttpClient httpClient)
        {

        }
    }

    public interface IDestiny2APIAuthorizationService
    {
        Task AuthorizeWithBungie(HttpClient httpclient);
    }
}
