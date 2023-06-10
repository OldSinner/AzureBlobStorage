using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobStorage.StorageConnector.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAzureConnector();
        }
    }
}