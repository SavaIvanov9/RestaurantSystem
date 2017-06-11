namespace RestaurantSystem.JsonManaging
{
    using RestaurantSystem.JsonModels.JsonModels;
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IJsonManager
    {
        IList<SupplyDocument> ParseProductsFile(byte[] document);

        IList<Sale> ParseSalesFile(byte[] document);
    }
}
