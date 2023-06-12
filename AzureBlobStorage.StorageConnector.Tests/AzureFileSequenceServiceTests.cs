using AzureBlobStorage.Model;
using AzureBlobStorage.StorageConnector.Services;
using FluentAssertions;

namespace AzureBlobStorage.StorageConnector.Tests
{
    public class AzureFileSequenceServiceTests
    {
        private readonly AzureFileSequenceService azureTableService;

        public AzureFileSequenceServiceTests(AzureFileSequenceService azureTableService)
        {
            this.azureTableService = azureTableService ?? throw new ArgumentNullException(nameof(azureTableService));
        }

        [Fact]
        public async Task CreateTableIfNotExistsAsyncTest()
        {

            var action = async () => await azureTableService.CreateTableIfNotExistsAsync();
            await action.Should().NotThrowAsync();
        }

        [Fact]
        public void CreateTableIfNotExistsTest()
        {
            var action = () => azureTableService.CreateTableIfNotExists();
            action.Should().NotThrow();
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
            var deleteResponse = await azureTableService.DeleteFileSequenceAsync(fileSeq.PartitionKey, fileSeq.RowKey);
            response.IsError.Should().BeFalse();
            deleteResponse.Should().BeTrue();
        }

        [Fact]
        public void RegisterFileTest()
        {
            var fileSeq = new AzureFileSequence()
            {
                Filename = "test.txt",
                Length = 5,
                Offset = 5,
                ETag = new Azure.ETag(),
                PartitionKey = "Unit-Test"
            };
            var response = azureTableService.RegisterFileSequence(fileSeq);
            var deleteResponse = azureTableService.DeleteFileSequence(fileSeq.PartitionKey, fileSeq.RowKey);
            response.IsError.Should().BeFalse();
            deleteResponse.Should().BeTrue();
        }

        [Fact]
        public async Task GestFileSequenceAsyncTest()
        {
            var response = await azureTableService.GetFileSequenceListAsync("Unit-Test");
            response.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void GestFileSequenceTest()
        {
            var response = azureTableService.GetFileSequenceList("Unit-Test");
            response.Count().Should().BeGreaterThan(0);
        }
    }
}