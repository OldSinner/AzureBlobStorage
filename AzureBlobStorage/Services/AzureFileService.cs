using Azure.Storage.Blobs.Models;
using AzureBlobStorage.Configuration;
using AzureBlobStorage.Model;
using AzureBlobStorage.StorageConnector.Interfaces;
using System.Text;
using System.Text.Json;
namespace AzureBlobStorage.Services
{
    public class AzureFileService
    {
        private readonly IAzureFileSequenceService azureFileSequenceService;
        private readonly IAzureBlobFileService azureBlobFileService;
        private readonly AzureConfiguration configuration;

        public AzureFileService(IAzureFileSequenceService azureFileSequenceService, IAzureBlobFileService azureBlobFileService, AzureConfiguration configuration)
        {
            this.azureFileSequenceService = azureFileSequenceService ?? throw new ArgumentNullException(nameof(azureFileSequenceService));
            this.azureBlobFileService = azureBlobFileService ?? throw new ArgumentNullException(nameof(azureBlobFileService));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<string> AddFileToStorageAsync<T>(T obj)
        {
            var text = JsonSerializer.Serialize(obj);
            var data = new MemoryStream(Encoding.UTF8.GetBytes(text));
            var enumerator = azureBlobFileService.GetBlobAsyncEnumerator();
            while (await enumerator.MoveNextAsync())
            {
                var blob = enumerator.Current;
                var offset = (int)blob.Properties.ContentLength!;
                if (blob.Properties.ContentLength + data.Length > configuration.MaxSeqSize)
                {
                    continue;
                }
                return await AddFile(blob.Name, data, typeof(T).Name, offset);
            }
            var blobName = Guid.NewGuid().ToString();
            return await AddFile(blobName, data, typeof(T).Name, 0);
        }

        private async Task<string> AddFile(string blob, Stream data, string className, long offset)
        {
            var response = await azureBlobFileService.AddDataToContainerAsync(blob, data);
            var seq = new AzureFileSequence
            {
                ClassName = className,
                FileSeqName = blob,
                Offset = offset,
                Length = data.Length,
                PartitionKey = configuration.FilePartition
            };
            var seqRes = await azureFileSequenceService.RegisterFileSequenceAsync(seq);
            if (seqRes == null)
            {
                throw new Exception("Failed to register file sequence");
            }
            return seq.RowKey;
        }
    }
}