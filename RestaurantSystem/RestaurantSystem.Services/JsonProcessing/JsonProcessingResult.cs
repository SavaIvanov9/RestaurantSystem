namespace RestaurantSystem.Services.JsonProcessing
{
    using RestaurantSystem.Infrastructure.Enumerations;

    public class JsonProcessingResult
    {
        public DocumentProcessingResult Result { get; set; }
        public string Message { get; set; }
    }
}
