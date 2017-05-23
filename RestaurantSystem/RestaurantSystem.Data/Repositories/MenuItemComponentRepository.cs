namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class MenuItemComponentRepository : GenericRepository<MenuItemComponent>, IRepository<MenuItemComponent>
    {
        public MenuItemComponentRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
