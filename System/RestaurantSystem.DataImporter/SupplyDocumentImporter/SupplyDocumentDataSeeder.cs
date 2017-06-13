namespace RestaurantSystem.DataImporter.SupplyDocumentImporter
{
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class SupplyDocumentDataSeeder : ISupplyDocumentDataSeeder
    {
        public void Seed(IList<SupplyDocument> documents, IRestaurantSystemData db)
        {
            Assembly.GetAssembly(typeof(IImporter))
                .GetTypes()
                .Where(x => !x.IsAbstract && !x.IsInterface && typeof(IImporter).IsAssignableFrom(x))
                .Select(x => (IImporter)Activator.CreateInstance(x))
                .OrderBy(x => x.Order)
                .ToList()
                .ForEach(x =>
                {
                    x.Import(db, documents);
                });
        }
    }
}
