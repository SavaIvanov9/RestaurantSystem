namespace RestaurantSystem.DataImporter.SupplyDocumentImporter.Importers
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction;
    using RestaurantSystem.Infrastructure.Constants;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CityImporter : BaseImporter, IImporter
    {

        public int Order => 1;

        public Action<IRestaurantSystemData, IList<SupplyDocument>> Import
        {
            get
            {
                return (db, documents) =>
                {
                    var cities = ExtractCities(documents)
                        .Select(x => x.Name)
                        .Distinct()
                        .ToList();

                    for (int i = 0; i < cities.Count; i++)
                    {
                        if (!CityExists(cities[i], db))
                        {
                            db.Cities.Add(new City
                            {
                                Name = cities[i]
                            });
                        }

                        this.SaveChanges(i, db);
                    }

                    db.SaveChanges();
                };
            }
        }

        private bool CityExists(string city, IRestaurantSystemData db)
        {
            var result = true;

            var dbCity = db.Cities
                .All()
                .Where(x => x.Name == city)
                .FirstOrDefault();

            if(dbCity == null)
            {
                result = false;
            }
            
            return result;
        }

        private List<City> ExtractCities(IList<SupplyDocument> documents)
        {
            var result = new List<City>();

            foreach(var doc in documents)
            {
                result.Add(doc.Supplier.Address.City);
            }

            return result;
        }
    }
}
