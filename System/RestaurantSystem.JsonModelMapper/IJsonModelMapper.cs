using RestaurantSystem.JsonModels.JsonModels;
using RestaurantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.MapperJsonModel
{
    public interface IJsonModelMapper
    {
        Address ConvertAddress(JsonAddress address);

        City ConvertCity(JsonCity city);

        MeasuringUnit ConvertMeasuringUnit(JsonMeasuringUnit measuringUnit);

        MenuItem ConvertMenuItem(JsonMenuItem menuItem);

        MenuItemComponent ConvertMenuItemComponent(JsonMenuItemComponent menuItemComponent);

        MenuItemType ConvertMenuItemType(JsonMenuItemType menuItemType);

        Product ConvertProduct(JsonProduct product);

        RestaurantBranch ConvertRestaurantBranch(JsonRestaurantBranch restaurantBranch);

        Sale ConvertSale(JsonSale sale);

        SaleComponent ConvertSaleComponent(JsonSaleComponent saleComponent);

        StoredProduct ConvertStoredProduct(JsonStoredProduct storedProduct);

        Supplier ConvertSupplier(JsonSupplier supplier);

        SupplyDocument ConvertSupplyDocument(JsonSupplyDocument supplyDocument);

        SupplyDocumentComponent ConvertSupplyDocumentComponent(JsonSupplyDocumentComponent supplyDocumentComponent);

        Waiter ConvertWaiter(JsonWaiter waiter);
    }
}
