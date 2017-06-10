namespace RestaurantSystem.JsonManaging
{
    using RestaurantSystem.JsonModels.JsonModels;
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IJsonManager
    {
        IList<JsonSupplyDocument> ImportProductsFile(byte[] document);

        IList<JsonSale> ImportSalesFile(byte[] document);
    }
}
