namespace RestaurantSystem.JsonManaging
{
    using Newtonsoft.Json;
    using RestaurantSystem.JsonModels.JsonModels;
    using System.Collections.Generic;

    public class JsonManager : IJsonManager
    {
        public IList<JsonSupplyDocument> ImportProductsFile(byte[] document)
        {
            var result = JsonConvert.DeserializeObject<List<JsonSupplyDocument>>(document.ToString());

            return result;
        }

        public IList<JsonSale> ImportSalesFile(byte[] document)
        {
            var result = JsonConvert.DeserializeObject<List<JsonSale>>(document.ToString());

            return result;
        }
    }
}
