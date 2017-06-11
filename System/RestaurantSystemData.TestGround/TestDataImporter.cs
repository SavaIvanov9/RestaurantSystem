using RestaurantSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JsonFilesGenerator;
using RestaurantSystem.Models;
using RestaurantSystem.Data.Migrations;
using RestaurantSystem.Data.Abstraction;

namespace RestaurantSystem.TestGround
{
    public class TestDataImporter
    {
        public void Import(IRestaurantSystemData db)
        {
            var city = new City
            {
                Name = "City 1"
            };

            db.Cities.Add(city);
            db.SaveChanges();

            var addr = new Address
            {
                ContactName = "Contact name 1",
                PhoneNumber = "PhoneNumber 1",
                PostCode = 1234,
                Street = "Street 1"
            };

            city.Addresses.Add(addr);
            db.Cities.Update(city);
            db.SaveChanges();

            var supplier = new Supplier
            {
                Name = "Supplier name 1"
            };

            addr.Suppliers.Add(supplier);
            db.Addresses.Update(addr);
            db.SaveChanges();

            //var branch = new RestaurantBranch
            //{
                
            //};

            var doc = new SupplyDocument
            {
                DocumentDate = DateTime.Now,
                ReferenceNumber = 12345
            };

            supplier.SupplyDocuments.Add(doc);
            db.Suppliers.Update(supplier);
            db.SaveChanges();

            //----

            var mu = new MeasuringUnit
            {
                Name = "MeasuringUnit name 1"
            };

            db.MeasuringUnits.Add(mu);
            db.SaveChanges();

            //----

            var product = new Product
            {
                AveragePrice = 1,
                Name = "Product name 1"
            };

            mu.Products.Add(product);
            db.MeasuringUnits.Update(mu);
            db.SaveChanges();

            //product.SupplyDocumentComponents.Add(component);
            //db.Products.Update(product);
            //db.SaveChanges();

            //----

            var component = new SupplyDocumentComponent
            {
                Price = 12,
                Quantity = 13,
                Product = product,
                ProductId = product.Id,
                SupplyDocument = doc,
                SupplyDocumentId = doc.Id
            };

            doc.SupplyDocumentComponents.Add(component);
            db.SaveChanges();
        }

        public void ImportWaiters(IRestaurantSystemData db)
        {
            for (int i = 0; i < 10; i++)
            {
                db.Waiters.Add(new Waiter
                {
                    Name = $"Test waiter {i}"
                });
            }

            db.SaveChanges();
        }
    }
}
