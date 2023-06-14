using AzureBlobStorage.StorageConnector;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobStorage.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAzureBlobStorage();
        }
    }
}