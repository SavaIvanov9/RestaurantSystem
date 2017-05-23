namespace RestaurantSystem.JsonManaging
{
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public class JsonManager : IJsonManager
    {
        public ICollection<Product> ImportProductsFile(byte[] document)
        {
            throw new NotImplementedException();
        }

        public ICollection<Sale> ImportSalesFile(byte[] document)
        {
            throw new NotImplementedException();
        }
    }
}
