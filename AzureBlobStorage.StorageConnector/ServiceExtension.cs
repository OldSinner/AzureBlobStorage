using Azure.Identity;
using AzureBlobStorage.Configuration;
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
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(services.BuildServiceProvider().GetRequiredService<AzureConfiguration>().ConnectionString);
            });
            services.AddSingleton<ITableServiceClientFactory, TableServiceClientFactory>();
            services.AddSingleton<IAzureBlobFileService, AzureBlobFileService>();
            services.AddSingleton<AzureTableService>();
        }
    }
}
