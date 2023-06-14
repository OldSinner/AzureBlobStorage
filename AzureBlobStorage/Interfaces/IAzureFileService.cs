namespace AzureBlobStorage.Interfaces
{
    public interface IAzureFileService
    {
        Task<string> AddDataToStorageAsync<T>(T obj);
        Task<T> GetDataFromStorage<T>(string key);
    }
}