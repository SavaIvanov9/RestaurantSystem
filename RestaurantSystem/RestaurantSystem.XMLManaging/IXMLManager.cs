namespace RestaurantSystem.XMLManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    interface IXMLManager
    {
        ICollection<Product> ImportFile(byte[] document);
    }
}
