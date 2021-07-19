using DestinyLoadoutBuilder.Data.Mappers;
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

        public async Task<Destiny2Player> GetDestiny2PlayerAsync(HttpClient httpClient)
        {
            try
            {
                var response = await httpClient.GetAsync(string.Concat(httpClient.BaseAddress, "/Destiny2/SearchDestinyPlayer/All/aaronf476/"));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Root dataFromAPI = JsonConvert.DeserializeObject<Root>(responseBody);
                //map data to the appropriate object
                var player = Destiny2PlayerMapper.MapDestiny2Player(dataFromAPI);
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
        Task<Destiny2Player> GetDestiny2PlayerAsync(HttpClient httpClient);
    }
}
