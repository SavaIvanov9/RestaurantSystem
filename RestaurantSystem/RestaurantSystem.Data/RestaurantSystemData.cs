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

        public AddressRepository Address =>
            (AddressRepository)this.GetRepository<Address>();

        public CityRepository City =>
            (CityRepository)this.GetRepository<City>();

        public MenuItemComponentRepository MenuItemComponent =>
            (MenuItemComponentRepository)this.GetRepository<MenuItemComponent>();

        public MeasuringUnitRepository MeasuringUnit =>
            (MeasuringUnitRepository)this.GetRepository<MeasuringUnit>();

        public MenuItemRepository MenuItem =>
            (MenuItemRepository)this.GetRepository<MenuItem>();

        public MenuItemsStoreRepository MenuItemsStore =>
            (MenuItemsStoreRepository)this.GetRepository<MenuItemsStore>();

        public MenuItemTypeRepository MenuItemType =>
            (MenuItemTypeRepository)this.GetRepository<MenuItemType>();

        public ProductRepository Product =>
            (ProductRepository)this.GetRepository<Product>();

        public ProductsStoreRepository ProductsStore =>
            (ProductsStoreRepository)this.GetRepository<ProductsStore>();

        public ProductTypeRepository ProductType =>
            (ProductTypeRepository)this.GetRepository<ProductType>();

        public RestaurantBranchRepository RestaurantBranch =>
            (RestaurantBranchRepository)this.GetRepository<RestaurantBranch>();

        public SaleComponentRepository SaleComponent =>
            (SaleComponentRepository)this.GetRepository<SaleComponent>();

        public SaleRepository Sale =>
            (SaleRepository)this.GetRepository<Sale>();

        public SupplierRepository Supplier =>
            (SupplierRepository)this.GetRepository<Supplier>();

        public SupplyDocumentRepository SupplyDocument =>
            (SupplyDocumentRepository)this.GetRepository<SupplyDocument>();

        public SupplyDocumentComponentRepository SupplyDocumentComponent =>
            (SupplyDocumentComponentRepository)this.GetRepository<SupplyDocumentComponent>();

        public WaiterRepository Waiter =>
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
