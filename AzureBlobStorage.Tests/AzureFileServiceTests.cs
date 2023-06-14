using AzureBlobStorage.Interfaces;
using AzureBlobStorage.Model;
using FluentAssertions;

namespace AzureBlobStorage.Tests
{
    public class AzureFileServiceTests
    {
        private readonly IAzureFileService service;

        public AzureFileServiceTests(IAzureFileService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        [Fact]
        public async Task AddFileToStorageAsyncTest()
        {
            var testFile = new AzureTestFile
            {
                PropertyOne = 1000,
                PropertyTwo = Guid.NewGuid().ToString(),
                PropertyThree = Guid.NewGuid().ToString(),
                PropertyFour = Guid.NewGuid().ToString(),
                PropertyFive = Guid.NewGuid().ToString(),
                PropertySix = Guid.NewGuid().ToString(),
                PropertySeven = Guid.NewGuid().ToString()
            };
            var response = await service.AddDataToStorageAsync<AzureTestFile>(testFile);
            var result = await service.GetDataFromStorageAsync<AzureTestFile>(response);

            response.Should().NotBeNullOrEmpty();
            result.Should().NotBeNull();
            result.PropertyOne.Should().Be(testFile.PropertyOne);
            result.PropertyTwo.Should().Be(testFile.PropertyTwo);
            result.PropertyThree.Should().Be(testFile.PropertyThree);
        }
    }
}