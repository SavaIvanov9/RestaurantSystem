namespace RestaurantSystem.JsonManaging
{
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public class JsonManager : IJsonManager
    {
        public ICollection<Product> ImportFile(byte[] document)
        {
            throw new NotImplementedException();
        }
    }
}
