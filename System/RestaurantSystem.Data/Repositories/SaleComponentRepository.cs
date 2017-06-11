namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class SaleComponentRepository : GenericRepository<SaleComponent>, IRepository<SaleComponent>
    {
        public SaleComponentRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}

