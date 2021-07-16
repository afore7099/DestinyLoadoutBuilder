using Destiny2DataModels.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Destiny2ApiServices.Requests
{
    public class Destiny2APIRequestBuilder : IDestiny2APIRequestBuilder
    {

        public Destiny2APIRequestBuilder()
        {
        }

        public async Task<Destiny2Player> GetDestiny2PlayerAsync(HttpClient httpClient)
        {

            using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, string.Concat(httpClient.BaseAddress, "Destiny2/1/Profile/4611686018433844788?components=Characters")))
            {
                requestMessage.Headers.Add("X-API-Key", "38b396e87c31442eb119564ad36b9f90");
                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await httpClient.SendAsync(requestMessage);
                    response.EnsureSuccessStatusCode();
                    Destiny2Player player = JsonConvert.DeserializeObject<Destiny2Player>(response.ToString());
                    return player;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error encountered: " + ex.Message);
                }

            }
        }
    }


    public interface IDestiny2APIRequestBuilder
    {
        Task<Destiny2Player> GetDestiny2PlayerAsync(HttpClient httpClient);
    }
}
