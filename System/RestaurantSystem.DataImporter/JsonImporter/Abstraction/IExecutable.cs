namespace RestaurantSystem.DataImporter.JsonImporter.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public interface IExecutable
    {
        int Order { get; }

        Action<IRestaurantSystemData, IList<SupplyDocument>> Execute { get; }
    }
}
