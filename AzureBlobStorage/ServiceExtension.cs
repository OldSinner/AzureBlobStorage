using AzureBlobStorage.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobStorage.StorageConnector
{
    public static class ServiceExtension
    {
        public static void AddAzureBlobStorage(this IServiceCollection services)
        {
            services.AddConfiguration();
            services.AddAzureConnector();
            
        }
    }
}
