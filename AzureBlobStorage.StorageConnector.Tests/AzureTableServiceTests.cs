using AzureBlobStorage.StorageConnector.Services;

namespace AzureBlobStorage.StorageConnector.Tests
{
    public class AzureTableServiceTests
    {
        private readonly AzureTableService azureTableService;

        public AzureTableServiceTests(AzureTableService azureTableService)
        {
            this.azureTableService = azureTableService ?? throw new ArgumentNullException(nameof(azureTableService));
        }

        [Fact]
        public async Task CreateTableIfNotExistsAsyncTest()
        {
            await azureTableService.CreateTableIfNotExistsAsync();
        }
    }
}