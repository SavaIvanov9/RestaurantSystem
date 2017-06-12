namespace RestaurantSystem.JsonManaging
{
    using Newtonsoft.Json;
    using RestaurantSystem.MapperJsonModel;
    using RestaurantSystem.JsonModels.JsonModels;
    using RestaurantSystem.Models;
    using System.Collections.Generic;
    using System.IO;

    public class JsonManager : IJsonManager
    {
        private JsonModelMapper jsonModelMapper = new JsonModelMapper();

        public IList<SupplyDocument> ParseProductsFile(byte[] document)
        {
            var result = new List<SupplyDocument>();

            using (var stream = new StreamReader(new MemoryStream(document)))
            {
                var jsonSupplyDocuments = JsonConvert.DeserializeObject<List<JsonSupplyDocument>>(stream.ReadToEnd());

                foreach (var item in jsonSupplyDocuments)
                {
                    result.Add(jsonModelMapper.ConvertSupplyDocument(item));
                }
            }

            return result;
        }

        public IList<Sale> ParseSalesFile(byte[] document)
        {
            var result = new List<Sale>();

            var jsonSale = JsonConvert.DeserializeObject<List<JsonSale>>(document.ToString());

            foreach (var item in jsonSale)
            {
                result.Add(jsonModelMapper.ConvertSale(item));
            }

            return result;
        }
    }
}
