namespace RestaurantSystem.JsonManaging
{
    using RestaurantSystem.JsonModels.JsonModels;
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IJsonManager
    {
        IList<SupplyDocument> ImportProductsFile(byte[] document);

        IList<Sale> ImportSalesFile(byte[] document);
    }
}
