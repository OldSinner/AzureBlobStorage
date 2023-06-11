using Azure;
using Azure.Data.Tables;

namespace AzureBlobStorage.Model
{
    public class AzureFileSequence : ITableEntity
    {
        public required string Filename { get; set; } = string.Empty;
        public required int Offset { get; set; }
        public required int Length { get; set; }
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset? Timestamp { get; set; } = default!;
        public ETag ETag { get; set; } = default!;
    }
}