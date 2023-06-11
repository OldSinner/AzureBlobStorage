using Azure.Data.Tables;
using AzureBlobStorage.Configuration;
using AzureBlobStorage.StorageConnector.Interfaces;

namespace AzureBlobStorage.StorageConnector.Services
{
    public class TableServiceClientFactory : ITableServiceClientFactory
    {
        private readonly AzureConfiguration configuration;

        public TableServiceClientFactory(AzureConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public TableServiceClient CreateService()
        {
            return new TableServiceClient(configuration.ConnectionString);
        }

        public TableClient CreateTableClient()
        {
            var client = CreateService();
            return client.GetTableClient(configuration.TableName);
        }
    }
}