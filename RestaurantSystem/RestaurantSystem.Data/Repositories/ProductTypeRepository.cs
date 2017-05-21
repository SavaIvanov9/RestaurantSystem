namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class ProductTypeRepository : GenericRepository<ProductType>, IRepository<ProductType>
    {
        public ProductTypeRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
