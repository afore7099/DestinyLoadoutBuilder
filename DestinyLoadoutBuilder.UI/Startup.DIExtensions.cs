namespace DestinyLoadoutBuilder.UI
{
    using DestinyLoadoutBuilder.Services.Authentication;
    using DestinyLoadoutBuilder.Services.Requests;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Net.Http;
    public static class StartupDIExtension
    {
        public static IServiceCollection AddServicesToDI(this IServiceCollection services)
        {
            //TODO: clean this up
            services.AddScoped<IDestiny2APIRequestService, Destiny2APIRequestService>();
            services.AddScoped<IDestiny2APIAuthorizationService, Destiny2APIAuthorizationService>();
            HttpClient httpClient = RegisterHttpClient();
            httpClient.DefaultRequestHeaders.Add("X-API-Key", "38b396e87c31442eb119564ad36b9f90");
            HttpClient authClient = RegisterAuthorizationClient();
            authClient.DefaultRequestHeaders.Add("X-API-Key", "38b396e87c31442eb119564ad36b9f90");
            services.AddScoped(sp => httpClient);
            return services;
        }

        private static HttpClient RegisterHttpClient()
        {
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://www.bungie.net/Platform")
            };
            return httpClient;
        }

        private static HttpClient RegisterAuthorizationClient()
        {
            HttpClient authClient = new HttpClient()
            {
                BaseAddress = new Uri("https://www.bungie.net/en/oauth/authorize")
            };
            return authClient;
        }
    }
}
