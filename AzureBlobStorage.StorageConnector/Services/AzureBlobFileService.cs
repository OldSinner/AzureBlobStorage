using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using AzureBlobStorage.StorageConnector.Configuration;
using AzureBlobStorage.StorageConnector.Interfaces;

namespace AzureBlobStorage.StorageConnector.Services
{
    public class AzureBlobFileService : IAzureBlobFileService
    {
        private readonly BlobServiceClient blobService;
        private readonly AzureConfiguration configuration;

        public AzureBlobFileService(BlobServiceClient blobService, AzureConfiguration configuration)
        {
            this.blobService = blobService ?? throw new ArgumentNullException(nameof(blobService));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<BlobAppendInfo> AddDataToContainerAsync(string filename, Stream data)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(filename);
            await blob.CreateIfNotExistsAsync();
            var response = await blob.AppendBlockAsync(data);
            return response.Value;
        }

        public BlobAppendInfo AddDataToContainer(string filename, Stream data)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(filename);
            blob.CreateIfNotExists();
            var response = blob.AppendBlock(data);
            return response.Value;
        }



    }
}
