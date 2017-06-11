namespace RestaurantSystem.Services.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.XMLManaging;
    using RestaurantSystem.Infrastructure.Enumerations;
    using RestaurantSystem.Services.XMLProcessing;

    public interface IXMLProcessingService
    {
        XMLProcessingResult ImportDocument(ImportingType importing,
            IRestaurantSystemData data, IXMLManager xmlManager, byte[] document);
    }
}
