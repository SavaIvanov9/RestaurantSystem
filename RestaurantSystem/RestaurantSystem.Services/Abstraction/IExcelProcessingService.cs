namespace RestaurantSystem.Services.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.ExcelManaging;
    using RestaurantSystem.Infrastructure.Enumerations;
    using System;

    public interface IExcelProcessingService
    {
        Tuple<DocumentProcessingResult, string> ImportSales(IRestaurantSystemData data,
            IExcelManager excelManager, byte[] document);
    }
}
