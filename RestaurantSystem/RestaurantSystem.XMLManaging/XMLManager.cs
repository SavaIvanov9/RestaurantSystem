namespace RestaurantSystem.XMLManaging
{
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public class XMLManager : IXMLManager
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
