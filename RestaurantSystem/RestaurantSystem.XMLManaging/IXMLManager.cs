namespace RestaurantSystem.XMLManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    interface IXMLManager
    {
        ICollection<Product> ImportProductsFile(byte[] document);

        ICollection<Sale> ImportSalesFile(byte[] document);
    }
}
