using Azure.Data.Tables;
using AzureBlobStorage.Configuration;
using AzureBlobStorage.Model;
using AzureBlobStorage.StorageConnector.Interfaces;

namespace AzureBlobStorage.StorageConnector.Services
{
    public class AzureFileSequenceService
    {
        private readonly ITableServiceClientFactory tableServiceClientFactory;

        public AzureFileSequenceService(ITableServiceClientFactory tableServiceClientFactory)
        {
            this.tableServiceClientFactory = tableServiceClientFactory ?? throw new ArgumentNullException(nameof(tableServiceClientFactory));
        }

        public async Task CreateTableIfNotExistsAsync()
        {
            var client = tableServiceClientFactory.CreateTableClient();
            await client.CreateIfNotExistsAsync();
        }

        public void CreateTableIfNotExists()
        {
            var client = tableServiceClientFactory.CreateTableClient();
            client.CreateIfNotExists();
        }
        public async Task<Azure.Response> RegisterFileSequenceAsync(AzureFileSequence fileSequence)
        {
            var client = tableServiceClientFactory.CreateTableClient();
            return await client.AddEntityAsync<AzureFileSequence>(fileSequence);
        }

        public Azure.Response RegisterFileSequence(AzureFileSequence fileSequence)
        {
            var client = tableServiceClientFactory.CreateTableClient();
            return client.AddEntity<AzureFileSequence>(fileSequence);
        }

    }
}