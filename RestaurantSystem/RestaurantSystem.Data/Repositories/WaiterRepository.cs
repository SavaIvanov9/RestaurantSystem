namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class WaiterRepository : GenericRepository<Waiter>, IRepository<Waiter>
    {
        public WaiterRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
