namespace RestaurantSystem.ExcelManaging
{
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public class ExcelManager : IExcelManager
    {
        public ICollection<Product> ImportProductsFile(byte[] document)
        {
            throw new NotImplementedException();
        }

        public ICollection<Sale> ImportSalesFile(byte[] document)
        {
            throw new NotImplementedException();
        }
    }
}
