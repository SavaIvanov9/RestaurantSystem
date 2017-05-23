namespace RestaurantSystem.Data.Abstraction
{
    using RestaurantSystem.Data.Repositories;

    public interface IRestaurantSystemData
    {
        AddressRepository Address { get; }

        CityRepository City { get; }

        MeasuringUnitRepository MeasuringUnit { get; }

        MenuItemComponentRepository MenuItemComponent { get; }

        MenuItemRepository MenuItem { get; }

        MenuItemsStoreRepository MenuItemsStore { get; }

        MenuItemTypeRepository MenuItemType { get; }

        ProductRepository Product { get; }

        ProductsStoreRepository ProductsStore { get; }

        ProductTypeRepository ProductType { get; }

        RestaurantBranchRepository RestaurantBranch { get; }

        SaleRepository Sale { get; }

        SaleComponentRepository SaleComponent { get; }

        SupplierRepository Supplier { get; }

        SupplyDocumentRepository SupplyDocument { get; }

        SupplyDocumentComponentRepository SupplyDocumentComponent { get; }

        WaiterRepository Waiter { get; }

        void SaveChanges();
    }
}
