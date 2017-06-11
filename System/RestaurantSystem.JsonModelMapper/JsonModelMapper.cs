using RestaurantSystem.JsonModels.JsonModels;
using RestaurantSystem.Models;

namespace RestaurantSystem.MapperJsonModel
{
    public class JsonModelMapper : IJsonModelMapper
    {
        public City ConvertCity(JsonCity city)
        {
            City result = new City();

            result.Name = city.Name;

            return result;
        }

        public MeasuringUnit ConvertMeasuringUnit(JsonMeasuringUnit measuringUnit)
        {
            MeasuringUnit result = new MeasuringUnit();
            result.Name = measuringUnit.Name;

            return result;
        }

        public MenuItem ConvertMenuItem(JsonMenuItem menuItem)
        {
            MenuItem result = new MenuItem();

            result.Name = menuItem.Name;
            result.Recipe = menuItem.Recipe;
            result.MenuItemType = this.ConvertMenuItemType(menuItem.MenuItemType);

            foreach(var item in menuItem.Components)
            {
                result.Components.Add(this.ConvertMenuItemComponent(item));
            }

            return result;
        }

        public MenuItemComponent ConvertMenuItemComponent(JsonMenuItemComponent menuItemComponent)
        {
            MenuItemComponent result = new MenuItemComponent();

            result.Product = this.ConvertProduct(menuItemComponent.Product);
            result.Quantity = menuItemComponent.Quantity;

            return result;
        }

        public MenuItemType ConvertMenuItemType(JsonMenuItemType menuItemType)
        {
            MenuItemType result = new MenuItemType();

            result.Name = menuItemType.Name;
            result.MenuItemTypeCode = menuItemType.MenuItemTypeCode;

            return result;
        }

        public Product ConvertProduct(JsonProduct product)
        {
            Product result = new Product();

            result.Name = product.Name;
            result.MeasuringUnit = this.ConvertMeasuringUnit(product.MeasuringUnit);

            return result;
        }

        public RestaurantBranch ConvertRestaurantBranch(JsonRestaurantBranch restaurantBranch)
        {
            RestaurantBranch result = new RestaurantBranch();

            result.Name = restaurantBranch.Name;
            result.Address = this.ConvertAddress(restaurantBranch.Address);

            return result;
        }

        public Sale ConvertSale(JsonSale sale)
        {
            Sale result = new Sale();

            result.Waiter = this.ConvertWaiter(sale.Waiter);
            result.TableNumber = sale.TableNumber;

            foreach(var item in sale.SaleComponents)
            {
                result.SaleComponents.Add(this.ConvertSaleComponent(item));
            }

            return result;
        }

        public SaleComponent ConvertSaleComponent(JsonSaleComponent saleComponent)
        {
            SaleComponent result = new SaleComponent();

            result.MenuItem = this.ConvertMenuItem(saleComponent.MenuItem);
            result.Quantity = saleComponent.Quantity;

            return result;
        }

        public StoredProduct ConvertStoredProduct(JsonStoredProduct storedProduct)
        {
            StoredProduct result = new StoredProduct();

            result.Product = this.ConvertProduct(storedProduct.Product);
            result.Quantity = storedProduct.Quantity;

            return result;
        }

        public Supplier ConvertSupplier(JsonSupplier supplier)
        {
            Supplier result = new Supplier();
            result.Name = supplier.Name;
            result.Address = this.ConvertAddress(supplier.Address);

            return result;
        }

        public SupplyDocument ConvertSupplyDocument(JsonSupplyDocument supplyDocument)
        {
            SupplyDocument result = new SupplyDocument();

            result.ReferenceNumber = supplyDocument.ReferenceNumber;
            result.DocumentDate = supplyDocument.DocumentDate;
            result.Supplier = this.ConvertSupplier(supplyDocument.Supplier);
            result.RestaurantBranch = this.ConvertRestaurantBranch(supplyDocument.RestaurantBranch);

            foreach (var item in supplyDocument.SupplyDocumentComponents)
            {
                result.SupplyDocumentComponents.Add(this.ConvertSupplyDocumentComponent(item));
            }

            return result;
        }

        public SupplyDocumentComponent ConvertSupplyDocumentComponent(JsonSupplyDocumentComponent supplyDocumentComponent)
        {
            SupplyDocumentComponent result = new SupplyDocumentComponent();

            result.Product = this.ConvertProduct(supplyDocumentComponent.Product);
            result.Quantity = supplyDocumentComponent.Quantity;
            result.Price = supplyDocumentComponent.Price;

            return result;
        }

        public Waiter ConvertWaiter(JsonWaiter waiter)
        {
            Waiter result = new Waiter();

            result.Name = waiter.Name;

            return result;
        }

        public Address ConvertAddress(JsonAddress address)
        {
            Address result = new Address();

            result.Street = address.Street;
            result.City = this.ConvertCity(address.City);
            result.PostCode = address.PostCode;
            result.ContactName = address.ContactName;
            result.PhoneNumber = address.PhoneNumber;

            return result;
        }
    }
}
