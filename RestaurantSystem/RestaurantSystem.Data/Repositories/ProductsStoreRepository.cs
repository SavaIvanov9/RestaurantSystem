namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class ProductsStoreRepository : GenericRepository<ProductsStore>, IRepository<ProductsStore>
    {
        public ProductsStoreRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}

