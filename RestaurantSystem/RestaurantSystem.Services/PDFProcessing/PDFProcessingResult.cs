namespace RestaurantSystem.Services.PDFProcessing
{
    using RestaurantSystem.Infrastructure.Enumerations;

    public class PDFProcessingResult
    {
        public DocumentProcessingResult Result { get; set; }
        public string Message { get; set; }
        public byte[] Document { get; set; }
    }
}
