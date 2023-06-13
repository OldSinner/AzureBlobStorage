namespace AzureBlobStorage.Configuration
{
    public class AzureConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string ContainerName { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;
        public string FilePartition { get; set; } = string.Empty;
        public int MaxSeqSize { get; set; }
    }
}