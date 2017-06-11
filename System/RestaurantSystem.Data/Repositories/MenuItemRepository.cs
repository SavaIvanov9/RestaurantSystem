namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class MenuItemRepository : GenericRepository<MenuItem>, IRepository<MenuItem>
    {
        public MenuItemRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
