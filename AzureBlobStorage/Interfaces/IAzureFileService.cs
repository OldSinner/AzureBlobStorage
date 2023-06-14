namespace AzureBlobStorage.Interfaces
{
    public interface IAzureFileService
    {
        /// <summary>
        /// Async method to add data to storage and register the file sequence i table storage
        /// </summary>
        /// <param name="obj">Object To Add</param>
        /// <typeparam name="T"> Type of Object to add. Object will be serialized to JSON</typeparam>
        /// <returns>Return key to get object</returns>
        Task<string> AddDataToStorageAsync<T>(T obj);
        /// <summary>
        /// Async method to get data from storage
        /// </summary>
        /// <param name="key">Key to get data</param>
        /// <typeparam name="T">Type of object to deserialized</typeparam>
        /// <returns> Object from storage</returns>
        Task<T> GetDataFromStorageAsync<T>(string key);
    }
}