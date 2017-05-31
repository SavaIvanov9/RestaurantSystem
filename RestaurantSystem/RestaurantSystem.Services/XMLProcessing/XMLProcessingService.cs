namespace RestaurantSystem.Services
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Infrastructure.Enumerations;
    using RestaurantSystem.Models;
    using RestaurantSystem.Services.Abstraction;
    using RestaurantSystem.Services.XMLProcessing;
    using RestaurantSystem.XMLManaging;
    using System;
    using System.Collections.Generic;

    public class XMLProcessingService : IXMLProcessingService
    {
        public XMLProcessingResult ImportDocument(ImportingType importing,
            IRestaurantSystemData data, IXMLManager xmlManager, byte[] document)
        {
            var result = new XMLProcessingResult
            {
                Result = DocumentProcessingResult.SuccessfulProcessing,
                Message = $"{importing.ToString()} imported successfully!"
            };

            try
            {
                if (importing == ImportingType.Sales)
                {
                    var sales = xmlManager.ImportSalesFile(document);

                    AddSales(data, sales);
                }
                else if (importing == ImportingType.Products)
                {
                    var products = xmlManager.ImportProductsFile(document);

                    AddProducts(data, products);
                }
            }
            catch (Exception ex)
            {
                result.Result = DocumentProcessingResult.UnSuccessfulProcessing;
                result.Message = ex.Message;
            }

            return result;
        }

        private void AddSales(IRestaurantSystemData data, IList<Sale> sales)
        {
            for (int i = 0; i < sales.Count; i++)
            {
                data.Sales.Add(sales[i]);

                CheckForSave(i, data);
            }

            data.SaveChanges();
        }

        private void AddProducts(IRestaurantSystemData data, IList<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                data.Products.Add(products[i]);

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
