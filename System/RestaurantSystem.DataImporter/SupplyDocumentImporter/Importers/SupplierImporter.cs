namespace RestaurantSystem.DataImporter.SupplyDocumentImporter.Importers
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SupplierImporter : BaseImporter, IImporter
    {
        public int Order => 4;

        public Action<IRestaurantSystemData, IList<SupplyDocument>> Import
        {
            get
            {
                return (db, documents) =>
                {
                    var suppliers = ExtractSuppliers(documents);

                    for (int i = 0; i < suppliers.Count; i++)
                    {
                        if (!SupplierExists(suppliers[i], db))
                        {
                            var supplierToAdd = new Supplier();
                            supplierToAdd.Name = suppliers[i].Name;

                            var street = suppliers[i].Address.Street;
                            var postCode = suppliers[i].Address.PostCode;

                            var supplierAddress = db.Addresses
                                .All()
                                .Where(x => x.Street == street
                                    && x.PostCode == postCode)
                                .FirstOrDefault();

                            supplierToAdd.AddressId = supplierAddress.Id;
                            supplierToAdd.Address = supplierAddress;

                            db.Suppliers.Add(supplierToAdd);
                        }
                    
                        this.SaveChanges(i, db);
                    }

                    db.SaveChanges();
                };
            }
        }

        private bool SupplierExists(Supplier supplier, IRestaurantSystemData db)
        {
            var dbSupplier = db.Suppliers
                .All()
                .Where(x => x.Name == supplier.Name)
                .FirstOrDefault();

            var result = dbSupplier != null;

            return result;
        }

        private List<Supplier> ExtractSuppliers(IList<SupplyDocument> documents)
        {
            var result = new List<Supplier>();

            foreach (var doc in documents)
            {
                result.Add(doc.Supplier);
            }

            return result;
        }
    }
}
