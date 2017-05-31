namespace RestaurantSystem.ExcelManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IExcelManager
    {
        IList<Product> ImportProductsFile(byte[] document);

        IList<Sale> ImportSalesFile(byte[] document);
    }
}
