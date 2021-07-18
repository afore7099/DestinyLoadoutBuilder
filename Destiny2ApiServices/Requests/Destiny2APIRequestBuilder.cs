using DestinyLoadoutBuilder.Data.Models;
using DestinyLoadoutBuilder.Data.Utilities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DestinyLoadoutBuilder.Services.Requests
{
    public class Destiny2APIRequestBuilder : IDestiny2APIRequestBuilder
    {

        public Destiny2APIRequestBuilder()
        {
        }

        public async Task<D2Player> GetDestiny2PlayerAsync(HttpClient httpClient)
        {           
            try
            {
                var response = await httpClient.GetAsync(string.Concat(httpClient.BaseAddress, "/Destiny2/SearchDestinyPlayer/All/aaronf476/"));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                D2Player player = new D2Player();
                player = JsonConvert.DeserializeObject<D2Player>(responseBody);
                return player;
            }
            catch (Exception ex)
            {
                throw new Exception("Error encountered: " + ex.Message);
            }
        }

        public string GetPropertyNameFromHash(long hash)
        {
            string propertyName = HashFinder.GetPropertyFromHash(hash);
            return propertyName;
        }

    }



    public interface IDestiny2APIRequestBuilder
    {
        Task<D2Player> GetDestiny2PlayerAsync(HttpClient httpClient);
    }
}
