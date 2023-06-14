using Azure.Data.Tables;
using AzureBlobStorage.Configuration;
using AzureBlobStorage.Model;
using AzureBlobStorage.StorageConnector.Interfaces;

namespace AzureBlobStorage.StorageConnector.Services
{
    public class AzureFileSequenceService : IAzureFileSequenceService
    {
        private const int MaxPerPage = 100;
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

        public async Task<AzureFileSequence> GetFileSequenceAsync(string partitionKey, string rowKey)
        {
            var client = tableServiceClientFactory.CreateTableClient();
            return await client.GetEntityAsync<AzureFileSequence>(partitionKey, rowKey);
        }

        public AzureFileSequence GetFileSequence(string partitionKey, string rowKey)
        {
            var client = tableServiceClientFactory.CreateTableClient();
            return client.GetEntity<AzureFileSequence>(partitionKey, rowKey);
        }

        public async Task<bool> DeleteFileSequenceAsync(string partitionKey, string rowKey)
        {
            var client = tableServiceClientFactory.CreateTableClient();
            var fileSequence = await client.DeleteEntityAsync(partitionKey, rowKey);
            return fileSequence.Status == 204;
        }
        public bool DeleteFileSequence(string partitionKey, string rowKey)
        {
            var client = tableServiceClientFactory.CreateTableClient();
            var fileSequence = client.DeleteEntity(partitionKey, rowKey);
            return fileSequence.Status == 204;
        }

    }
}