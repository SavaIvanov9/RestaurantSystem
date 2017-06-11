using RestaurantSystem.JsonModels.JsonModels;
using System;

namespace JsonFilesGenerator
{
    public class TestObjectRandomGenerator : ITestObjectRandomGenerator
    {
        private Random random = new Random();

        public JsonRestaurantBranch GenerateRestaurantBranch()
        {
            JsonRestaurantBranch result = new JsonRestaurantBranch();
            result.Name = "Pri Pesho";
            result.Address = new JsonAddress();
            result.Address.Street = "Yantra";
            result.Address.PostCode = 1302;
            result.Address.City = new JsonCity();
            result.Address.City.Name = "Sofia";

            return result;
        }

        public JsonAddress GenerateAddress()
        {
            string[] validStreets = { "Moskovska", "Washington", "Ravna", "Lyava", "Byala", "Dolna", "Gorna", "Polska" };
            JsonAddress result = new JsonAddress();
            result.City = this.GenerateCity();
            result.Street = validStreets[random.Next(validStreets.Length)] + " Str.";
            result.PostCode = (short)random.Next(1000, 9999);

            return result;
        }

        public JsonCity GenerateCity()
        {
            string[] validCities = { "Sofia", "Burgas", "Varna", "Plovdiv" };
            JsonCity result = new JsonCity();
            result.Name = validCities[random.Next(validCities.Length)];

            return result;
        }

        public JsonSupplyDocument GenerateSupplyDocument()
        {
            JsonSupplyDocument result = new JsonSupplyDocument();

            result.RestaurantBranch = this.GenerateRestaurantBranch();
            result.ReferenceNumber = random.Next(1, 1000);
            result.DocumentDate = new DateTime(2017, 1, 1).AddDays(random.Next(180));
            result.Supplier = this.GenerateSupplier();
            int numberofComponents = random.Next(1, 7);
            for (int i=0; i<numberofComponents; i++)
            {
                result.SupplyDocumentComponents.Add(this.GenerateSupplyDocumentComponent());
            }

            return result;
        }

        public JsonSupplier GenerateSupplier()
        {
            string[] validNames = { "Kompoti", "ABC", "Maxi", "Mini", "Star", "Kiss", "Gruyo", "Swan" };
            JsonSupplier result = new JsonSupplier();

            result.Name = validNames[random.Next(validNames.Length)] + " OOD";
            result.Address = this.GenerateAddress();

            return result;
        }

        public JsonSupplyDocumentComponent GenerateSupplyDocumentComponent()
        {
            JsonSupplyDocumentComponent result = new JsonSupplyDocumentComponent();
            result.Product = this.GenerateProduct();
            result.Quantity = (decimal)random.Next(5000) / 100.00m;
            result.Price = (decimal)random.Next(2000) / 100.00m;
            return result;
        }

        public JsonWaiter GenerateWaiter()
        {
            string[] validNames = { "Gosho", "Pesho", "Ivan", "Maria", "Ana", "Gana" };
            var result = new JsonWaiter();
            result.Name = validNames[random.Next(validNames.Length)];
            return result;
        }

        public JsonProduct GenerateProduct()
        {
            var result = new JsonProduct();

            string[] validProductNames = { "flour",
                "oil",
                "cucumbers",
                "beef",
                "pork",
                "poultry",
                "salt",
                "eggs",
                "spaghetti",
                "black pepper",
                "tomatoes" };

            result.Name = validProductNames[random.Next(validProductNames.Length)];
            result.MeasuringUnit = this.GenerateMeasuringUnit();

            return result;
        }

        public JsonMeasuringUnit GenerateMeasuringUnit()
        {
            var result = new JsonMeasuringUnit();

            string[] validMeasuringUnits = { "kg", "l", "pc", "g", "ml" };
            result.Name = validMeasuringUnits[random.Next(validMeasuringUnits.Length)];

            return result;
        }

        public JsonSale GenerateSale()
        {
            JsonSale result = new JsonSale();
            result.Waiter = this.GenerateWaiter();
            result.TableNumber = (byte)random.Next(10);
            //TODO: add branch

            int numberofComponents = random.Next(1, 7);
            for (int i = 0; i < numberofComponents; i++)
            {
                result.SaleComponents.Add(this.GenerateSaleComponent());
            }

            return result;
        }

        public JsonSaleComponent GenerateSaleComponent()
        {
            JsonSaleComponent result = new JsonSaleComponent();
            result.MenuItem = this.GenerateMenuItem();
            result.Quantity = random.Next(5);

            return result;
        }

        public JsonMenuItem GenerateMenuItem()
        {
            JsonMenuItem result = new JsonMenuItem();
            string[] validNames = { "Tarator", "Chiken Soup", "Gyuvech", "Shopska Salad", "Spaghetti", "Pizza", "Krem karamel",
                "Greek salad", "Lazagna", "Shkembe Soup", "Melba" };

            result.Name = validNames[random.Next(validNames.Length)];
            result.MenuItemType = this.GenerateMenuItemType();

            int numberofComponents = random.Next(1, 7);
            for (int i = 0; i < numberofComponents; i++)
            {
                result.Components.Add(this.GenerateMenuItemComponent());
            }

            return result;
        }

        public JsonMenuItemType GenerateMenuItemType()
        {
            JsonMenuItemType result = new JsonMenuItemType();
            string[] validNames = { "Soup", "Salad", "Starter", "Main", "Desert", "Drink" };
            result.Name = validNames[random.Next(validNames.Length)];

            return result;
        }

        public JsonMenuItemComponent GenerateMenuItemComponent()
        {
            JsonMenuItemComponent result = new JsonMenuItemComponent();
            result.Product = this.GenerateProduct();
            result.Quantity = (decimal)random.Next(1000) / 100.00m;

            return result;
        }
    }
}
