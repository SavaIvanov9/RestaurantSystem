namespace RestaurantSystem.DataImporter.SupplyDocumentImporter.Importers
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction;
    using RestaurantSystem.Infrastructure.Constants;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BranchImporter : BaseImporter, IImporter
    {
        public int Order => 3;

        public Action<IRestaurantSystemData, IList<SupplyDocument>> Import
        {
            get
            {
                return (db, documents) =>
                {
                    var branch = documents[0].RestaurantBranch;

                    if (!BranchExists(branch, db))
                    {
                        var branchToAdd = new RestaurantBranch();
                        branchToAdd.Name = branch.Name;

                        var branchAddress = db.Addresses
                            .All()
                            .Where(
                                x => x.Street == branch.Address.Street &&
                                    x.PostCode == branch.Address.PostCode
                            )
                            .FirstOrDefault();

                        branchAddress.Branches.Add(branchToAdd);
                    }

                    db.SaveChanges();
                };
            }
        }

        private bool BranchExists(RestaurantBranch branch, IRestaurantSystemData db)
        {
            var result = true;

            var dbBranch = db.RestaurantBranches
                .All()
                .Where(x => x.Name == branch.Name)
                .FirstOrDefault();

            if (dbBranch == null)
            {
                result = false;
            }

            return result;
        }
    }
}
