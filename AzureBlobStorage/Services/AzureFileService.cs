using AzureBlobStorage.StorageConnector.Interfaces;
using System.Text;
using System.Text.Json;
namespace AzureBlobStorage.Services
{
    public class AzureFileService
    {
        private readonly IAzureFileSequenceService azureFileSequenceService;
        private readonly IAzureBlobFileService azureBlobFileService;

        public AzureFileService(IAzureFileSequenceService azureFileSequenceService, IAzureBlobFileService azureBlobFileService)
        {
            this.azureFileSequenceService = azureFileSequenceService ?? throw new ArgumentNullException(nameof(azureFileSequenceService));
            this.azureBlobFileService = azureBlobFileService ?? throw new ArgumentNullException(nameof(azureBlobFileService));
        }

        public async Task AddFileToStorage<T>(T obj)
        {
            var text = JsonSerializer.Serialize(obj);
            var data = new MemoryStream(Encoding.UTF8.GetBytes(text));
        }
    }
}