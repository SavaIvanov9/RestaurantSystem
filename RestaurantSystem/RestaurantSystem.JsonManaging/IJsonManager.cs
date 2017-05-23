namespace RestaurantSystem.JsonManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IJsonManager
    {
        ICollection<Product> ImportFile(byte[] document);
    }
}
