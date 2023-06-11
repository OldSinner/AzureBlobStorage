using AzureBlobStorage.Model;
using AzureBlobStorage.StorageConnector.Services;
using FluentAssertions;

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

        [Fact]
        public void CreateTableIfNotExistsTest()
        {
            azureTableService.CreateTableIfNotExists();
        }

        [Fact]
        public async Task RegisterFileTestAsync()
        {
            var fileSeq = new AzureFileSequence()
            {
                Filename = "test.txt",
                Length = 5,
                Offset = 5,
                ETag = new Azure.ETag(),
                PartitionKey = "Unit-Test"
            };
            var response = await azureTableService.RegisterFileSequenceAsync(fileSeq);
            response.IsError.Should().BeFalse();
        }
    }
}