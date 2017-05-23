namespace RestaurantSystem.ExcelManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IExcelManager
    {
        ICollection<Product> ImportProductsFile(byte[] document);

        ICollection<Sale> ImportSalesFile(byte[] document);
    }
}
