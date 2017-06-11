namespace RestaurantSystem.Services.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.ExcelManaging;
    using RestaurantSystem.Infrastructure.Enumerations;
    using RestaurantSystem.Services.ExcelProcessing;

    public interface IExcelProcessingService
    {
        ExcelProcessingResult ImportDocument(ImportingType importing,
            IRestaurantSystemData data, IExcelManager excelManager, byte[] document);
    }
}
