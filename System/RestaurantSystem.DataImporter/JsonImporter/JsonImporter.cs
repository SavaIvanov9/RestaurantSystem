namespace RestaurantSystem.DataImporter.JsonImporter
{
    using RestaurantSystem.Data;
    using RestaurantSystem.DataImporter.JsonImporter.Abstraction;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class JsonImporter : IJsonImporter
    {
        public void Import(IList<SupplyDocument> documents)
        {
            Assembly.GetAssembly(typeof(IExecutable))
                .GetTypes()
                .Where(x => !x.IsAbstract && !x.IsInterface && typeof(IExecutable).IsAssignableFrom(x))
                .Select(x => (IExecutable)Activator.CreateInstance(x))
                .OrderBy(x => x.Order)
                .ToList()
                .ForEach(x =>
                {
                    x.Execute(new RestaurantSystemData(), documents);
                });
        }
    }
}
