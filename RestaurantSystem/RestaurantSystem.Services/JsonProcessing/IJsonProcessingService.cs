namespace RestaurantSystem.Services.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.JsonManaging;
    using RestaurantSystem.Infrastructure.Enumerations;
    using System;

    public interface IJsonProcessingService
    {
        Tuple<DocumentProcessingResult, string> ImportDocument(ImportingType importing,
             IRestaurantSystemData data, IJsonManager jsonManager, byte[] document);
    }
}
