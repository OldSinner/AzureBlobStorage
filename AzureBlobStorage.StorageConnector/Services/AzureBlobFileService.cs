using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using AzureBlobStorage.Configuration;
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
        public Task<BlobContainerInfo?> CreateContainerIfNotExistAsync() => CreateContainerIfNotExistAsync("");
        public async Task<BlobContainerInfo?> CreateContainerIfNotExistAsync(string containerName = "")
        {
            if (containerName == "")
            {
                containerName = configuration.ContainerName;
            }
            var client = blobService.GetBlobContainerClient(containerName);
            var response = await client.CreateIfNotExistsAsync();
            return response?.Value;
        }
        public BlobContainerInfo? CreateContainerIfNotExist() => CreateContainerIfNotExist("");
        public BlobContainerInfo? CreateContainerIfNotExist(string containerName)
        {
            if (containerName == "")
            {
                containerName = configuration.ContainerName;
            }
            var client = blobService.GetBlobContainerClient(containerName);
            var response = client.CreateIfNotExists();
            return response?.Value;
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

        public async Task<bool> DeleteFullBlobAsync(string filename)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(filename);
            var response = await blob.DeleteIfExistsAsync();
            return response.Value;
        }
        public bool DeleteFullBlob(string filename)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(filename);
            var response = blob.DeleteIfExists();
            return response.Value;
        }

        public async Task<BlobProperties> GetBlobInfoAsync(string filename)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(filename);
            var response = await blob.GetPropertiesAsync();
            return response.Value;
        }

        public BlobProperties GetBlobInfo(string filename)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(filename);
            var response = blob.GetProperties();
            return response.Value;
        }


    }
}
