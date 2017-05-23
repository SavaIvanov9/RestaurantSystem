namespace RestaurantSystem.Data
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public class RestaurantSystemData : IRestaurantSystemData
    {
        private readonly IRestaurantSystemDbContext _context;
        private readonly IDictionary<Type, object> _repositories;

        public RestaurantSystemData()
            : this(new RestaurantSystemDbContext())
        {
        }

        public RestaurantSystemData(IRestaurantSystemDbContext context)
        {
            this._context = context;
            this._repositories = new Dictionary<Type, object>();
        }

        public AddressRepository Addresses =>
            (AddressRepository)this.GetRepository<Address>();

        public CityRepository Cities =>
            (CityRepository)this.GetRepository<City>();

        public MenuItemComponentRepository MenuItemComponents =>
            (MenuItemComponentRepository)this.GetRepository<MenuItemComponent>();

        public MeasuringUnitRepository MeasuringUnits =>
            (MeasuringUnitRepository)this.GetRepository<MeasuringUnit>();

        public MenuItemRepository MenuItems =>
            (MenuItemRepository)this.GetRepository<MenuItem>();

        public MenuItemsStoreRepository MenuItemsStores =>
            (MenuItemsStoreRepository)this.GetRepository<MenuItemsStore>();

        public MenuItemTypeRepository MenuItemTypes =>
            (MenuItemTypeRepository)this.GetRepository<MenuItemType>();

        public ProductRepository Products =>
            (ProductRepository)this.GetRepository<Product>();

        public ProductsStoreRepository ProductsStores =>
            (ProductsStoreRepository)this.GetRepository<ProductsStore>();

        public ProductTypeRepository ProductTypes =>
            (ProductTypeRepository)this.GetRepository<ProductType>();

        public RestaurantBranchRepository RestaurantBranches =>
            (RestaurantBranchRepository)this.GetRepository<RestaurantBranch>();

        public SaleComponentRepository SaleComponents =>
            (SaleComponentRepository)this.GetRepository<SaleComponent>();

        public SaleRepository Sales =>
            (SaleRepository)this.GetRepository<Sale>();

        public SupplierRepository Suppliers =>
            (SupplierRepository)this.GetRepository<Supplier>();

        public SupplyDocumentRepository SupplyDocuments =>
            (SupplyDocumentRepository)this.GetRepository<SupplyDocument>();

        public SupplyDocumentComponentRepository SupplyDocumentComponents =>
            (SupplyDocumentComponentRepository)this.GetRepository<SupplyDocumentComponent>();

        public WaiterRepository Waiters =>
            (WaiterRepository)this.GetRepository<Waiter>();

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var repositoryType = typeof(T);

            if (!this._repositories.ContainsKey(repositoryType))
            {
                var type = typeof(GenericRepository<T>);

                this.SetType(repositoryType, ref type);

                this._repositories.Add(repositoryType, Activator.CreateInstance(type, this._context));
            }

            return (IRepository<T>)this._repositories[repositoryType];
        }

        private void SetType(Type repositoryType, ref Type type)
        {
            if (repositoryType.IsAssignableFrom(typeof(Address)))
                type = typeof(AddressRepository);
        }
    }
}
