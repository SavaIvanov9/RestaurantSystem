namespace RestaurantSystem.JsonManaging
{
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public class JsonManager : IJsonManager
    {
        public IList<Product> ImportProductsFile(byte[] document)
        {
            throw new NotImplementedException();
        }

        public IList<Sale> ImportSalesFile(byte[] document)
        {
            throw new NotImplementedException();
        }
    }
}
