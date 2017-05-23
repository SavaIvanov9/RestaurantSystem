namespace RestaurantSystem.XMLManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    interface IXMLManager
    {
        IList<Product> ImportProductsFile(byte[] document);

        IList<Sale> ImportSalesFile(byte[] document);
    }
}
