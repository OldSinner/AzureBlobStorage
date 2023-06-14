using AzureBlobStorage.Configuration;
using AzureBlobStorage.Interfaces;
using AzureBlobStorage.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobStorage.StorageConnector
{
    public static class ServiceExtension
    {
        public static void AddAzureBlobStorage(this IServiceCollection services)
        {
            services.AddConfiguration();
            services.AddAzureConnector();
            services.AddSingleton<IAzureFileService, AzureFileService>();

        }
    }
}
