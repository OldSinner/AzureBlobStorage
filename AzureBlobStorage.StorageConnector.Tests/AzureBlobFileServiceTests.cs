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
            var filename = "AddDataToContainerAsyncTest.txt";
            var data = new MemoryStream(Encoding.UTF8.GetBytes("test"));
            var response = await azureBlobFileService.AddDataToContainerAsync(filename, data);
            var propeties = await azureBlobFileService.GetBlobInfoAsync(filename);
            var deleteResult = await azureBlobFileService.DeleteFullBlobAsync(filename);
            response.Should().NotBeNull();
            propeties.ContentLength.Should().Be(4);
            deleteResult.Should().BeTrue();
        }
        [Fact]
        public void AddDataToContainerTest()
        {
            var filename = "AddDataToContainerTest.txt";
            var data = new MemoryStream(Encoding.UTF8.GetBytes("test"));
            var response = azureBlobFileService.AddDataToContainer(filename, data);
            var propeties = azureBlobFileService.GetBlobInfo(filename);
            var deleteResult = azureBlobFileService.DeleteFullBlob(filename);
            response.Should().NotBeNull();
            propeties.ContentLength.Should().Be(4);
            deleteResult.Should().BeTrue();
        }
        [Fact]
        public async Task GetBlobDataAsync()
        {
            var filename = "ReadDataAsyncTest.txt";
            var data = new MemoryStream(Encoding.UTF8.GetBytes("testabctest"));
            var response = await azureBlobFileService.AddDataToContainerAsync(filename, data);

            var readData = await azureBlobFileService.GetBlobDataAsync(filename, 4, 3);
            var blobdata = Encoding.UTF8.GetString(readData);

            var deleteResult = await azureBlobFileService.DeleteFullBlobAsync(filename);

            blobdata.Should().Be("abc");
            response.Should().NotBeNull();
            deleteResult.Should().BeTrue();
        }
        [Fact]
        public void GetBlobData()
        {
            var filename = "ReadDataAsyncTest.txt";
            var data = new MemoryStream(Encoding.UTF8.GetBytes("testabctest"));
            var response = azureBlobFileService.AddDataToContainer(filename, data);

            var readData = azureBlobFileService.GetBlobData(filename, 4, 3);
            var blobdata = Encoding.UTF8.GetString(readData);

            var deleteResult = azureBlobFileService.DeleteFullBlob(filename);

            blobdata.Should().Be("abc");
            response.Should().NotBeNull();
            deleteResult.Should().BeTrue();
        }
        [Fact]
        public async Task GetBlobsAsyncEnum()
        {
            var filename = "GetBlobsAsyncEnum.txt";
            var data = new MemoryStream(Encoding.UTF8.GetBytes("testabctest"));
            var response = azureBlobFileService.AddDataToContainer(filename, data);

            var enumerator = azureBlobFileService.GetBlobAsyncEnumerator();
            await enumerator.MoveNextAsync();

            var deleteResult = azureBlobFileService.DeleteFullBlob(filename);

            enumerator.Current.Should().NotBeNull();
            response.Should().NotBeNull();
            deleteResult.Should().BeTrue();
        }
    }
}