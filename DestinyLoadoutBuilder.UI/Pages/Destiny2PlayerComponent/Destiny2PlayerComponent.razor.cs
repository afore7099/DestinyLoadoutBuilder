namespace DestinyLoadoutBuilder.UI.Pages.Destiny2PlayerComponent
{
    using Destiny2ApiServices.Requests;
    using Destiny2DataModels.Models;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http;
    using System.Threading.Tasks;
    public partial class Destiny2PlayerComponent
    {
        [Inject]
        protected IDestiny2APIRequestBuilder APIRequestBuilder { get; set; }

        [Inject]
        protected HttpClient HttpClient { get; set; }
        public Destiny2Player Player { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Player = await APIRequestBuilder.GetDestiny2PlayerAsync(HttpClient);
        }
    }
}
