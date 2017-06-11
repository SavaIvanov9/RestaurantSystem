namespace RestaurantSystem.XMLManaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RestaurantSystem.Models;

    public class FakeXMLManager : IXMLManager
    {
        public IList<Product> ImportProductsFile(byte[] document)
        {
            var result = new List<Product>();

            for (int i = 0; i < 100; i++)
            {
                result.Add(new Product
                {
                    Name = $"Test Product {i}",
                    //MeasuringUnit
                    AveragePrice = i * 10,
                });
            }

            return result;
        }

        public IList<Sale> ImportSalesFile(byte[] document)
        {
            throw new NotImplementedException();
        }
    }
}
