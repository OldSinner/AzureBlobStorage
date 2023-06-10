
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobStorage.StorageConnector.Configuration
{
    public static class ServiceExtension
    {
        public static void AddConfiguration(this IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            var azureConfig = new AzureConfiguration();
            configuration.Bind("AzureConfiguration", azureConfig);

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton < AzureConfiguration>(azureConfig);
        }
    }
}
