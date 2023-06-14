using AzureBlobStorage.Model;
using AzureBlobStorage.StorageConnector.Interfaces;
using FluentAssertions;

namespace AzureBlobStorage.StorageConnector.Tests
{
    public class AzureFileSequenceServiceTests
    {
        private readonly IAzureFileSequenceService azureTableService;

        public AzureFileSequenceServiceTests(IAzureFileSequenceService azureTableService)
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
                Length = 5,
                Offset = 5,
                ETag = new Azure.ETag(),
                PartitionKey = "Unit-Test",
                FileSeqName = "test.txt",
                ClassName = "AzureBlobStorage.Model.AzureFileSequence"
            };
            var response = await azureTableService.RegisterFileSequenceAsync(fileSeq);
            var getresponse = await azureTableService.GetFileSequenceAsync(fileSeq.PartitionKey, fileSeq.RowKey);
            var deleteResponse = await azureTableService.DeleteFileSequenceAsync(fileSeq.PartitionKey, fileSeq.RowKey);
            getresponse.Should().NotBeNull();
            response.IsError.Should().BeFalse();
            deleteResponse.Should().BeTrue();
        }

        [Fact]
        public void RegisterFileTest()
        {
            var fileSeq = new AzureFileSequence()
            {
                Length = 5,
                Offset = 5,
                ETag = new Azure.ETag(),
                PartitionKey = "Unit-Test",
                FileSeqName = "test.txt",
                ClassName = "AzureBlobStorage.Model.AzureFileSequence"
            };
            var response = azureTableService.RegisterFileSequence(fileSeq);
            var getresponse = azureTableService.GetFileSequence(fileSeq.PartitionKey, fileSeq.RowKey);
            var deleteResponse = azureTableService.DeleteFileSequence(fileSeq.PartitionKey, fileSeq.RowKey);
            getresponse.Should().NotBeNull();
            response.IsError.Should().BeFalse();
            deleteResponse.Should().BeTrue();
        }

    }
}