namespace RestaurantSystem.DataImporter.JsonImporter.Importers
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.DataImporter.JsonImporter.Abstraction;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CityImporter : IExecutable
    {
        private int saveChangesCount = 50;

        public int Order => 1;

        public Action<IRestaurantSystemData, IList<SupplyDocument>> Execute
        {
            get
            {
                return (db, documents) =>
                {
                    var cities = ExtractCities(documents);

                    for (int i = 0; i < cities.Count; i++)
                    {
                        if (!CheckIfCityExists(cities[i], db))
                        {
                            db.Cities.Add(new City
                            {
                                Name = cities[i].Name
                            });
                        }

                        SaveChanges(i, db);
                    }

                    db.SaveChanges();
                };
            }
        }

        private void SaveChanges(int count, IRestaurantSystemData db)
        {
            if(count % saveChangesCount == 0)
            {
                db.SaveChanges();
            }
        }

        private bool CheckIfCityExists(City city, IRestaurantSystemData db)
        {
            var result = true;

            var dbCity = db.Cities
                .All()
                .Where(x => x.Name == city.Name)
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
