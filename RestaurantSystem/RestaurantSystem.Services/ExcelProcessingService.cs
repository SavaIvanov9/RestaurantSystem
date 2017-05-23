namespace RestaurantSystem.Services
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.ExcelManaging;
    using RestaurantSystem.Infrastructure.Enumerations;
    using RestaurantSystem.Models;
    using RestaurantSystem.Services.Abstraction;
    using System;
    using System.Collections.Generic;

    public class ExcelProcessingService : IExcelProcessingService
    {
        public Tuple<DocumentProcessingResult, string> ImportSales(IRestaurantSystemData data,
            IExcelManager excelManager, byte[] document)
        {
            Tuple<DocumentProcessingResult, string> result = new Tuple<DocumentProcessingResult, string>
                (DocumentProcessingResult.SuccessfulProcessing, "Sales imported successfully!");

            try
            {
                var sales = excelManager.ImportSalesFile(document);

                AddSales(data, sales);
            }
            catch (Exception ex)
            {
                result = new Tuple<DocumentProcessingResult, string>
                    (DocumentProcessingResult.UnSuccessfulProcessing, ex.Message);
            }

            return result;
        }

        private void AddSales(IRestaurantSystemData data, IList<Sale> sales)
        {
            for (int i = 0; i < sales.Count; i++)
            {
                data.Sale.Add(sales[i]);

                CheckForSave(i, data);
            }

            data.SaveChanges();
        }

        private void CheckForSave(long number, IRestaurantSystemData data)
        {
            if (number % 50 == 0)
            {
                data.SaveChanges();
            }
        }
    }
}
