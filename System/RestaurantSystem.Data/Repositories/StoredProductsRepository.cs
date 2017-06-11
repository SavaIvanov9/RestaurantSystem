namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class StoredProductsRepository : GenericRepository<StoredProduct>, IRepository<StoredProduct>
    {
        public StoredProductsRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}

