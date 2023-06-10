using AzureBlobStorage.StorageConnector.Interfaces;
using AzureBlobStorage.StorageConnector.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobStorage.StorageConnector
{
    public static class ServiceExtension
    {
        public static void AddAzureConnector(this IServiceCollection services)
        {
            services.AddTransient<IAzureConnector, AzureConnector>();
        }
    }
}
