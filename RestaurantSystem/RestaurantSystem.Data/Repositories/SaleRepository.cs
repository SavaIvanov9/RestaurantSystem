namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class SaleRepository : GenericRepository<SaleRepository>, IRepository<SaleRepository>
    {
        public SaleRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
