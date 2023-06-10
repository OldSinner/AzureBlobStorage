using System.Text;
using AzureBlobStorage.StorageConnector.Interfaces;

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
        public async Task AddDataToContainerAsyncTest()
        {
            var filename = "test.txt";
            var data = new MemoryStream(Encoding.UTF8.GetBytes("test"));
            var response = await azureBlobFileService.AddDataToContainerAsync(filename, data);
            Assert.NotNull(response);
        }
    }
}