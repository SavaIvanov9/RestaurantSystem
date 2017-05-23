namespace RestaurantSystem.JsonManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IJsonManager
    {
        ICollection<Product> ImportProductsFile(byte[] document);

        ICollection<Sale> ImportSalesFile(byte[] document);
    }
}
