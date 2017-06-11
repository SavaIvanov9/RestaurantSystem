namespace RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public interface IImporter
    {
        int Order { get; }

        Action<IRestaurantSystemData, IList<SupplyDocument>> Import { get; }
    }
}
