namespace RestaurantSystem.Services
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Infrastructure.Enumerations;
    using RestaurantSystem.PDFManaging;
    using RestaurantSystem.Services.Abstraction;
    using RestaurantSystem.Services.PDFProcessing;
    using System;
    using System.Linq;

    public class PDFProcessingService : IPDFProcessingService
    {
        public PDFProcessingResult ExportDocument(ExportingType exporting,
            IRestaurantSystemData data, ISalesPDFManager pdfManager)
        {
            var result = new PDFProcessingResult
            {
                Result = DocumentProcessingResult.SuccessfulProcessing,
                Message = $"{exporting.ToString()} exported successfully!"
            };

            try
            {
                if (exporting == ExportingType.Sales)
                {
                    var sales = data.Sales
                        .All()
                        .ToList();

                    var document = pdfManager.ExportSalesFile(sales);

                    result.Document = document;
                }
            }
            catch (Exception ex)
            {
                result.Result = DocumentProcessingResult.UnSuccessfulProcessing;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
