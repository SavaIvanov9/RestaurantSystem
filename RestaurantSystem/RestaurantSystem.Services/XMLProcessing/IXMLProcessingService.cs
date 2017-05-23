namespace RestaurantSystem.Services.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.XMLManaging;
    using RestaurantSystem.Infrastructure.Enumerations;
    using System;

    public interface IXMLProcessingService
    {
        Tuple<DocumentProcessingResult, string> ImportDocument(ImportingType importing,
            IRestaurantSystemData data, IXMLManager xmlManager, byte[] document);
    }
}
