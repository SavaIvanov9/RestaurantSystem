namespace RestaurantSystem.Services.ExcelProcessing
{
    using RestaurantSystem.Infrastructure.Enumerations;

    public class ExcelProcessingResult
    {
        public DocumentProcessingResult Result { get; set; }
        public string Message { get; set; }
    }
}
