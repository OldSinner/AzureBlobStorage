using Azure.Data.Tables;
using AzureBlobStorage.Configuration;
using AzureBlobStorage.Model;
using AzureBlobStorage.StorageConnector.Interfaces;

namespace AzureBlobStorage.StorageConnector.Services
{
    public class AzureFileSequenceService
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

        public async Task<IEnumerable<AzureFileSequence>> GetFileSequenceListAsync(string partitionKey)
        {
            var list = new List<AzureFileSequence>();
            var client = tableServiceClientFactory.CreateTableClient();
            var fileSequence = client.QueryAsync<AzureFileSequence>(x => x.PartitionKey == partitionKey, MaxPerPage);
            await foreach (var l in fileSequence)
            {
                list.Add(l);
            }
            return list;
        }

        public IEnumerable<AzureFileSequence> GetFileSequenceList(string partitionKey)
        {
            var client = tableServiceClientFactory.CreateTableClient();
            var fileSequence = client.Query<AzureFileSequence>(x => x.PartitionKey == partitionKey, MaxPerPage);
            return fileSequence;
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