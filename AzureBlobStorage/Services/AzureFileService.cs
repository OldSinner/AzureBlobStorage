using AzureBlobStorage.StorageConnector.Interfaces;

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
    }
}