namespace RestaurantSystem.XMLManaging
{
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public class XMLManager : IXMLManager
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
