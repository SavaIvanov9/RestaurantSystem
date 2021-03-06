﻿namespace RestaurantSystem.Data.Abstraction
{
    using RestaurantSystem.Data.Repositories;

    public interface IRestaurantSystemData
    {
        AddressRepository Addresses { get; }

        CityRepository Cities { get; }

        MeasuringUnitRepository MeasuringUnits { get; }

        MenuItemComponentRepository MenuItemComponents { get; }

        MenuItemRepository MenuItems { get; }

        //MenuItemsStoreRepository MenuItemsStores { get; }

        MenuItemTypeRepository MenuItemTypes { get; }

        ProductRepository Products { get; }

        StoredProductsRepository StoredProducts { get; }

        ProductTypeRepository ProductTypes { get; }

        RestaurantBranchRepository RestaurantBranches { get; }

        SaleRepository Sales { get; }

        SaleComponentRepository SaleComponents { get; }

        SupplierRepository Suppliers { get; }

        SupplyDocumentRepository SupplyDocuments { get; }

        SupplyDocumentComponentRepository SupplyDocumentComponents { get; }

        WaiterRepository Waiters { get; }

        int SaveChanges();
    }
}
