namespace RestaurantSystem.ExcelManaging
{
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public class ExcelManager : IExcelManager
    {
        public ICollection<Product> ImportFile(byte[] document)
        {
            throw new NotImplementedException();
        }
    }
}
