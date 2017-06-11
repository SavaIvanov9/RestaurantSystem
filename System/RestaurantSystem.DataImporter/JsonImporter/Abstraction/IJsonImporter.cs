namespace RestaurantSystem.DataImporter.JsonImporter.Abstraction
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IJsonImporter
    {
        void Import(IList<SupplyDocument> documents);
    }
}
