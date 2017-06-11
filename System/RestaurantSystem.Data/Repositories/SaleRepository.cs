namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class SaleRepository : GenericRepository<Sale>, IRepository<Sale>
    {
        public SaleRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
