namespace RestaurantSystem.Services.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.ExcelManaging;
    using RestaurantSystem.Infrastructure.Enumerations;
    using System;

    public interface IJsonProcessingService
    {
        Tuple<DocumentProcessingResult, string> ImportDocument(ImportingType importing,
            IRestaurantSystemData data, IExcelManager excelManager, byte[] document);
    }
}
