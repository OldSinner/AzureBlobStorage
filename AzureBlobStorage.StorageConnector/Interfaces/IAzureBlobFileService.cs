using Azure.Storage.Blobs.Models;

namespace AzureBlobStorage.StorageConnector.Interfaces
{
    public interface IAzureBlobFileService
    {
        public Task<BlobContainerInfo?> CreateContainerIfNotExistAsync();
        public Task<BlobContainerInfo?> CreateContainerIfNotExistAsync(string containerName = "");
        public BlobContainerInfo? CreateContainerIfNotExist();
        public BlobContainerInfo? CreateContainerIfNotExist(string containerName);
        public Task<BlobAppendInfo> AddDataToContainerAsync(string filename, Stream data);
        public BlobAppendInfo AddDataToContainer(string filename, Stream data);
        public Task<bool> DeleteFullBlobAsync(string filename);
        public bool DeleteFullBlob(string filename);
        public Task<BlobProperties> GetBlobInfoAsync(string filename);
        public BlobProperties GetBlobInfo(string filename);
        public Task<byte[]> GetBlobDataAsync(string filename, int Offset, int Length);
        public byte[] GetBlobData(string filename, int Offset, int Length);
        public IAsyncEnumerator<BlobItem> GetBlobAsyncEnumerator();

    }
}