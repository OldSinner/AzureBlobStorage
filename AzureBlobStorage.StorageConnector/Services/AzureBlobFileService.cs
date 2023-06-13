using Azure;
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

        public async Task<BlobAppendInfo> AddDataToContainerAsync(string fileSeqName, Stream data)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(fileSeqName);
            await blob.CreateIfNotExistsAsync();
            var response = await blob.AppendBlockAsync(data);
            return response.Value;
        }

        public BlobAppendInfo AddDataToContainer(string fileSeqName, Stream data)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(fileSeqName);
            blob.CreateIfNotExists();
            var response = blob.AppendBlock(data);
            return response.Value;
        }

        public async Task<bool> DeleteFullBlobAsync(string fileSeqName)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(fileSeqName);
            var response = await blob.DeleteIfExistsAsync();
            return response.Value;
        }
        public bool DeleteFullBlob(string fileSeqName)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(fileSeqName);
            var response = blob.DeleteIfExists();
            return response.Value;
        }

        public async Task<BlobProperties> GetBlobInfoAsync(string fileSeqName)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(fileSeqName);
            var response = await blob.GetPropertiesAsync();
            return response.Value;
        }

        public BlobProperties GetBlobInfo(string fileSeqName)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(fileSeqName);
            var response = blob.GetProperties();
            return response.Value;
        }

        public async Task<byte[]> GetBlobDataAsync(string fileSeqName, int Offset, int Length)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(fileSeqName);
            var response = await blob.OpenReadAsync();
            response.Seek(Offset, SeekOrigin.Begin);
            var buffer = new byte[Length];
            await response.ReadAsync(buffer, 0, Length);
            return buffer;
        }
        public byte[] GetBlobData(string fileSeqName, int Offset, int Length)
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var blob = client.GetAppendBlobClient(fileSeqName);
            var response = blob.OpenRead();
            response.Seek(Offset, SeekOrigin.Begin);
            var buffer = new byte[Length];
            response.Read(buffer, 0, Length);
            return buffer;
        }
        public IAsyncEnumerator<BlobItem> GetBlobAsyncEnumerator()
        {
            var client = blobService.GetBlobContainerClient(configuration.ContainerName);
            var response = client.GetBlobsAsync();
            return response.GetAsyncEnumerator();
        }
    }
}

