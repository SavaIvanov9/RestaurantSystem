namespace RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface ISupplyDocumentDataSeeder
    {
        void Seed(IList<SupplyDocument> documents, IRestaurantSystemData db);
    }
}
