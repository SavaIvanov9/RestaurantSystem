namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class ProductRepository : GenericRepository<Product>, IRepository<Product>
    {
        public ProductRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
