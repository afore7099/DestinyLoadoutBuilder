namespace DestinyLoadoutBuilder.UI
{
    using DestinyLoadoutBuilder.Services.Requests;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Net.Http;
    public static class StartupDIExtension
    {
        public static IServiceCollection AddServicesToDI(this IServiceCollection services)
        {
            services.AddScoped<IDestiny2APIRequestBuilder, Destiny2APIRequestBuilder>();
            HttpClient httpClient = RegisterHttpClient();
            httpClient.DefaultRequestHeaders.Add("X-API-Key", "38b396e87c31442eb119564ad36b9f90");
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
    }
}
