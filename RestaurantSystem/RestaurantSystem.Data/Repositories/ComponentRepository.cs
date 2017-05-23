namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class ComponentRepository : GenericRepository<MenuItemComponent>, IRepository<MenuItemComponent>
    {
        public ComponentRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
