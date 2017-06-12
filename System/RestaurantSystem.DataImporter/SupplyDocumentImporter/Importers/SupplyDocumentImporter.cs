namespace RestaurantSystem.DataImporter.SupplyDocumentImporter.Importers
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction;
    using RestaurantSystem.Infrastructure.Constants;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SupplyDocumentImporter : BaseImporter, IImporter
    {

        public int Order => 7;

        public Action<IRestaurantSystemData, IList<SupplyDocument>> Import
        {
            get
            {
                return (db, documents) =>
                {
                    for (int i = 0; i < documents.Count; i++)
                    {
                        if (!SupplyDocumentExists(documents[i], db))
                        {
                            var supplyDocumentToAdd = new SupplyDocument
                                {
                                    ReferenceNumber = documents[i].ReferenceNumber,
                                    DocumentDate = documents[i].DocumentDate,
                                    SupplierId = documents[i].Supplier.Id,
                                    Supplier = documents[i].Supplier
                                };

                            var name = documents[i].RestaurantBranch.Name;

                            var documentBranch = db.RestaurantBranches
                                .All()
                                .Where(x => x.Name == name)
                                .FirstOrDefault();

                            if (documentBranch != null)
                            {
                                supplyDocumentToAdd.RestaurantBranchId = documentBranch.Id;
                                supplyDocumentToAdd.RestaurantBranch = documentBranch;
                            }

                            foreach (var component in documents[i].SupplyDocumentComponents)
                            {
                                var storedProduct = ProductInStoredProducts(component.Product, db);
                                if (storedProduct != null)
                                {
                                    storedProduct.Quantity += component.Quantity;
                                    db.StoredProducts.Update(storedProduct);
                                }
                                else
                                {
                                    var storedProductToAdd = new StoredProduct();
                                    storedProductToAdd.Product = component.Product;
                                    storedProductToAdd.Quantity = component.Quantity;
                                    //TODO: Calculate the average price of the product and update the necessary product
                                }

                                var product = db.Products
                                    .All()
                                    .FirstOrDefault(x => x.Name == component.Product.Name);

                                if (component.SupplyDocument != null)
                                {
                                    var supplyDocument = db.SupplyDocuments
                                        .All()
                                        .FirstOrDefault(x => x.ReferenceNumber == component.SupplyDocument.ReferenceNumber);

                                    if (product != null && supplyDocument != null)
                                    {
                                        db.SupplyDocumentComponents.Add(new SupplyDocumentComponent
                                        {
                                            Price = component.Price,
                                            Product = product,
                                            ProductId = product.Id,
                                            Quantity = component.Quantity,
                                            SupplyDocument = supplyDocument,
                                            SupplyDocumentId = supplyDocument.Id
                                        });
                                    }
                                }
                            }
                        }

                        this.SaveChanges(i, db);
                    }

                    db.SaveChanges();
                };
            }
        }

        private bool SupplyDocumentExists(SupplyDocument supplyDocument, IRestaurantSystemData db)
        {
            var result = true;

            var dbSupplyDocument = db.SupplyDocuments
                .All()
                .Where(
                    x => x.ReferenceNumber == supplyDocument.ReferenceNumber &&
                        x.Supplier.Name == supplyDocument.Supplier.Name
                    )
                .FirstOrDefault();

            if (dbSupplyDocument == null)
            {
                result = false;
            }

            return result;
        }

        private StoredProduct ProductInStoredProducts(Product product, IRestaurantSystemData db)
        {
            StoredProduct result = db.StoredProducts
                .All()
                .Where(x => x.Product.Name == product.Name)
                .FirstOrDefault();

            return result;
        }
    }
}
