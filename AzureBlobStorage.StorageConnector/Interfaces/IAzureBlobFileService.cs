using Azure.Storage.Blobs.Models;

namespace AzureBlobStorage.StorageConnector.Interfaces
{
    public interface IAzureBlobFileService
    {
        public Task<BlobAppendInfo> AddDataToContainerAsync(string filename, Stream data);
        public BlobAppendInfo AddDataToContainer(string filename, Stream data);

    }
}