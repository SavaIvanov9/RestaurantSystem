namespace RestaurantSystem.Data.Abstraction
{
    using RestaurantSystem.Data.Repositories;

    public interface IRestaurantSystemData
    {
        AddressRepository Address { get; }
        CityRepository City { get; }
        MenuItemComponentRepository Component { get; }
        MenuItemRepository MenuItem { get; }
        MenuItemTypeRepository MenuItemType { get; }
        ProductRepository Product { get; }
        ProductTypeRepository ProductType { get; }
        RestaurantBranchRepository RestaurantBranch { get; }
        SaleRepository Sale { get; }
        SupplierRepository Supplier { get; }
        WaiterRepository Waiter { get; }

        void SaveChanges();
    }
}
