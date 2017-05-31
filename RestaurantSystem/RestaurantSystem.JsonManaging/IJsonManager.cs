namespace RestaurantSystem.JsonManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IJsonManager
    {
        IList<Product> ImportProductsFile(byte[] document);

        IList<Sale> ImportSalesFile(byte[] document);
    }
}
