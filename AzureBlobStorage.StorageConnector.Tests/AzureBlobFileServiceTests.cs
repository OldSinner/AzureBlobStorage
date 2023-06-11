using System.Text;
using AzureBlobStorage.StorageConnector.Interfaces;
using FluentAssertions;

namespace AzureBlobStorage.StorageConnector.Tests
{
    public class AzureBlobFileServiceTests
    {
        private readonly IAzureBlobFileService azureBlobFileService;

        public AzureBlobFileServiceTests(IAzureBlobFileService azureBlobFileService)
        {
            this.azureBlobFileService = azureBlobFileService ?? throw new ArgumentNullException(nameof(azureBlobFileService));
        }
        [Fact]
        public async Task CreateContainerAsyncTest()
        {
            var action = async () => await azureBlobFileService.CreateContainerIfNotExistAsync();
            await action.Should().NotThrowAsync();
        }
        [Fact]
        public void CreateContainerTest()
        {
            var action = () => azureBlobFileService.CreateContainerIfNotExist();
            action.Should().NotThrow();
        }

        [Fact]
        public async Task AddDataToContainerAsyncTest()
        {
            var filename = "test.txt";
            var data = new MemoryStream(Encoding.UTF8.GetBytes("test"));
            var response = await azureBlobFileService.AddDataToContainerAsync(filename, data);
            response.Should().NotBeNull();
            var propeties = await azureBlobFileService.GetBlobInfoAsync(filename);
            propeties.ContentLength.Should().Be(4);
            var deleteResult = await azureBlobFileService.DeleteFullBlobAsync(filename);
            deleteResult.Should().BeTrue();
        }
        [Fact]
        public void AddDataToContainerTest()
        {
            var filename = "test.txt";
            var data = new MemoryStream(Encoding.UTF8.GetBytes("test"));
            var response = azureBlobFileService.AddDataToContainer(filename, data);
            response.Should().NotBeNull();
            var propeties = azureBlobFileService.GetBlobInfo(filename);
            propeties.ContentLength.Should().Be(4);
            var deleteResult = azureBlobFileService.DeleteFullBlob(filename);
            deleteResult.Should().BeTrue();
        }

    }
}