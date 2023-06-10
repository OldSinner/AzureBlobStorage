using Azure.Identity;
using AzureBlobStorage.StorageConnector.Configuration;
using AzureBlobStorage.StorageConnector.Interfaces;
using AzureBlobStorage.StorageConnector.Services;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobStorage.StorageConnector
{
    public static class ServiceExtension
    {
        public static void AddAzureConnector(this IServiceCollection services)
        {
            services.AddConfiguration();
            services.AddSingleton<IAzureConnector, AzureConnector>();
        }
    }
}
