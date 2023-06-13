using AzureBlobStorage.Model;

namespace AzureBlobStorage.StorageConnector.Interfaces
{
    public interface IAzureFileSequenceService
    {
        public Task CreateTableIfNotExistsAsync();
        public void CreateTableIfNotExists();
        public Task<Azure.Response> RegisterFileSequenceAsync(AzureFileSequence fileSequence);
        public Azure.Response RegisterFileSequence(AzureFileSequence fileSequence);
        public Task<IEnumerable<AzureFileSequence>> GetFileSequenceListAsync(string partitionKey);
        public IEnumerable<AzureFileSequence> GetFileSequenceList(string partitionKey);
        public Task<bool> DeleteFileSequenceAsync(string partitionKey, string rowKey);
        public bool DeleteFileSequence(string partitionKey, string rowKey);
        public Task<AzureFileSequence> GetFileSequenceAsync(string partitionKey, string rowKey);
        public AzureFileSequence GetFileSequence(string partitionKey, string rowKey);

    }
}