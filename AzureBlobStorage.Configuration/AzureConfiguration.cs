namespace AzureBlobStorage.Configuration
{
    public class AzureConfiguration
    {
        public string AzureBlobConnectionString { get; set; } = string.Empty;
        public string AzureTableConnectionString { get; set; } = string.Empty;
        public string ContainerName { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;
        public string FilePartition { get; set; } = string.Empty;
        public int MaxSeqSize { get; set; }
    }
}