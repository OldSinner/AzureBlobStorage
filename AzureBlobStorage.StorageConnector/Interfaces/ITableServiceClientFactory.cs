using Azure.Data.Tables;

namespace AzureBlobStorage.StorageConnector.Interfaces
{
    public interface ITableServiceClientFactory
    {
        public TableServiceClient CreateService();
        public TableClient CreateTableClient();
    }
}