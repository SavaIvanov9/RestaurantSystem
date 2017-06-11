using RestaurantSystem.JsonModels.JsonModels;
using System.Collections.Generic;

namespace RestaurantSystem.DataImporter.Importers
{
    public interface IImporter
    {
        void Import(IList<JsonSupplyDocument> documents);
    }
}
