namespace AzureBlobStorage.Model
{
    public class AzureFileSequence
    {
        public string Filename { get; set; } = string.Empty;
        public int Offset { get; set; }
        public int Length { get; set; }
        public DateTime Created { get; set; }
    }
}