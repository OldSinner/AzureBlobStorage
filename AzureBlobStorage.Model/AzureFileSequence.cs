using Azure;
using Azure.Data.Tables;

namespace AzureBlobStorage.Model
{
    public class AzureFileSequence : ITableEntity
    {
        public required long Offset { get; set; }
        public required long Length { get; set; }
        public required string FileSeqName { get; set; } = string.Empty;
        public required string ClassName { get; set; } = string.Empty;
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset? Timestamp { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
    }
}