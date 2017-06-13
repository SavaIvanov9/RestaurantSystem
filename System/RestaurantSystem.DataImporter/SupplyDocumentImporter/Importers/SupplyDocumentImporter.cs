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
                            var docummentName = documents[i].Supplier.Name;

                            var supplier = db.Suppliers
                            .All()
                            .FirstOrDefault(x => x.Name == docummentName);

                            var name = documents[i].RestaurantBranch.Name;

                            var documentBranch = db.RestaurantBranches
                                .All()
                                .Where(x => x.Name == name)
                                .FirstOrDefault();

                            if (documentBranch != null && supplier != null)
                            {
                                var supplyDocumentToAdd = new SupplyDocument
                                {
                                    ReferenceNumber = documents[i].ReferenceNumber,
                                    DocumentDate = documents[i].DocumentDate,
                                    SupplierId = supplier.Id,
                                    Supplier = supplier,
                                    RestaurantBranchId = documentBranch.Id,
                                    RestaurantBranch = documentBranch
                                };

                                db.SupplyDocuments.Add(supplyDocumentToAdd);
                                db.SaveChanges();

                                ImportSupplyDocumentComponents(documents[i], db, documentBranch, supplyDocumentToAdd);

                                db.SaveChanges();
                            }
                        }

                        this.SaveChanges(i, db);
                    }

                    db.SaveChanges();
                };
            }
        }

        private void ImportSupplyDocumentComponents(SupplyDocument document, IRestaurantSystemData db,
            RestaurantBranch documentBranch, SupplyDocument supplyDocument)
        {
            foreach (var component in document.SupplyDocumentComponents)
            {
                var storedProduct = FindProductInStoredProducts(component.Product, db);

                var product = db.Products
                    .All()
                    .FirstOrDefault(x => x.Name == component.Product.Name);

                if (product != null)
                {

                    if (storedProduct != null)
                    {
                        storedProduct.Quantity += component.Quantity;
                        db.StoredProducts.Update(storedProduct);
                        db.SaveChanges();
                    }
                    else
                    {
                        var storedProductToAdd = new StoredProduct
                        {
                            Product = product,
                            ProductId = product.Id,
                            Quantity = component.Quantity,
                            RestaurantBranch = documentBranch,
                            RestaurantBranchId = documentBranch.Id
                        };

                        db.StoredProducts.Add(storedProductToAdd);
                        db.SaveChanges();
                    }

                    if (supplyDocument != null)
                    {
                        supplyDocument.SupplyDocumentComponents.Add(new SupplyDocumentComponent
                        {
                            Price = component.Price,
                            Product = product,
                            ProductId = product.Id,
                            Quantity = component.Quantity,
                        });

                        db.SupplyDocuments.Update(supplyDocument);
                        db.SaveChanges();
                    }
                }
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

        private StoredProduct FindProductInStoredProducts(Product product, IRestaurantSystemData db)
        {
            StoredProduct result = db.StoredProducts
                .All()
                .Where(x => x.Product.Name == product.Name)
                .FirstOrDefault();

            return result;
        }
    }
}
