namespace RestaurantSystem.Services.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Infrastructure.Enumerations;
    using RestaurantSystem.PDFManaging;
    using RestaurantSystem.Services.PDFProcessing;

    public interface IPDFProcessingService
    {
        PDFProcessingResult ExportDocument(ExportingType exporting,
            IRestaurantSystemData data, IPDFManager pdfManager);
    }
}
