namespace DestinyLoadoutBuilder.UI.Pages.Destiny2PlayerComponent
{
    using DestinyLoadoutBuilder.Data.Models;
    using DestinyLoadoutBuilder.Services.Authentication;
    using DestinyLoadoutBuilder.Services.Requests;
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public partial class Destiny2PlayerComponent
    {
        [Inject]
        protected IDestiny2APIRequestService APIRequestBuilder { get; set; }

        [Inject]
        protected IDestiny2APIAuthorizationService AuthService { get; set; }

        [Inject]
        protected HttpClient HttpClient { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private readonly Guid _stateValue = Guid.NewGuid();

        private HttpClient AuthClient { get; set; }
        public Destiny2Player Player { get; set; }

        public Destiny2PlayerComponent()
        {
            Player = new Destiny2Player();
            AuthClient = new HttpClient()
            {
                BaseAddress = new Uri("https://www.bungie.net/en/oauth/authorize")
            };
            AuthClient.DefaultRequestHeaders.Add("X-API-Key", "38b396e87c31442eb119564ad36b9f90");
        }

        protected override async Task OnInitializedAsync()
        {
            //Player = await APIRequestBuilder.GetDestiny2PlayerAsync(HttpClient);
            //await AuthService.AuthorizeWithBungie(AuthClient);
        }

        private void AuthBtnClick()
        {
            string authURI = string.Concat("https://www.bungie.net/en/oauth/authorize", "?client_id=37100&response_type=code&state=", _stateValue);
            NavigationManager.NavigateTo(authURI);
        }
    }
}