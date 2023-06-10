namespace AzureBlobStorage.StorageConnector.Configuration
{
    public class AzureConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string ContainerName { get; set; } = string.Empty;
        public int PageSize { get; set; }
    }
}