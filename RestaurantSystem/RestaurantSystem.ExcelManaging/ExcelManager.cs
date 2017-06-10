namespace RestaurantSystem.ExcelManaging
{
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public class ExcelManager : IExcelManager
    {
        public IList<Product> ImportProductsFile(byte[] document)
        {
            throw new NotImplementedException();
        }

        public IList<Sale> ImportSalesFile(byte[] document)
        {
            throw new NotImplementedException();
        }
    }
}
