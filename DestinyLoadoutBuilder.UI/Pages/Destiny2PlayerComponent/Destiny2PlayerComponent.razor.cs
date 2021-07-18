namespace DestinyLoadoutBuilder.UI.Pages.Destiny2PlayerComponent
{
    using DestinyLoadoutBuilder.Services.Requests;
    using DestinyLoadoutBuilder.Data.Models;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public partial class Destiny2PlayerComponent
    {
        [Inject]
        protected IDestiny2APIRequestBuilder APIRequestBuilder { get; set; }

        [Inject]
        protected HttpClient HttpClient { get; set; }
        public D2Player Player { get; set; }

        public Destiny2PlayerComponent()
        {
            Player = new D2Player();           
        }
        protected override async Task OnInitializedAsync()
        {
            Player = await APIRequestBuilder.GetDestiny2PlayerAsync(HttpClient);
        }
    }
}
