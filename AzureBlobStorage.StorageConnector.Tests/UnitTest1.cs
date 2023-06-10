using AzureBlobStorage.StorageConnector.Interfaces;

namespace AzureBlobStorage.StorageConnector.Tests;

public class UnitTest1
{
    private readonly IAzureConnector azureConnector;

    public UnitTest1(IAzureConnector azureConnector)
    {
        this.azureConnector = azureConnector ?? throw new ArgumentNullException(nameof(azureConnector));
    }
    [Fact]
    public void Test1()
    {

    }
}