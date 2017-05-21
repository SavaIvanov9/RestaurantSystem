namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class ProductRepository : GenericRepository<ProductRepository>, IRepository<ProductRepository>
    {
        public ProductRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
