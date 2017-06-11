namespace RestaurantSystem.DataImporter.SupplyDocumentImporter.Importers
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductImporter : BaseImporter, IImporter
    {
        public int Order => 6;

        public Action<IRestaurantSystemData, IList<SupplyDocument>> Import
        {
            get
            {
                return (db, documents) =>
                {
                    var products = ExtractProducts(documents);

                    for (int i = 0; i < products.Count; i++)
                    {
                        if (!ProductExists(products[i], db))
                        {
                            var name = products[i].MeasuringUnit.Name;

                            var unit = db.MeasuringUnits
                                .All()
                                .Where(x => x.Name == name)
                                .FirstOrDefault();

                            if (unit != null)
                            {
                                unit.Products.Add(new Product
                                {
                                    Name = products[i].Name,
                                    AveragePrice = products[i].AveragePrice,
                                });

                                db.MeasuringUnits.Update(unit);
                            }

                            this.SaveChanges(i, db);
                        }
                    }

                    db.SaveChanges();
                };
            }
        }

        private bool ProductExists(Product product, IRestaurantSystemData db)
        {
            var result = true;

            var dbProduct = db.Products
                .All()
                .Where(x => x.Name == product.Name)
                .FirstOrDefault();

                result = dbProduct != null;

            return result;
        }

        private List<Product> ExtractProducts(IList<SupplyDocument> documents)
        {
            var result = new List<Product>();

            foreach (var doc in documents)
            {
                foreach (var component in doc.SupplyDocumentComponents)
                {
                    component.Product.AveragePrice = component.Price; //TODO: SET AVERAGE PRICE!
                    result.Add(component.Product); 
                }
            }

            return result;
        }
    }
}
