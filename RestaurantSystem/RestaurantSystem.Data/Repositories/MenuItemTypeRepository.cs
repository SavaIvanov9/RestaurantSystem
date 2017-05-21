namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class MenuItemTypeRepository : GenericRepository<MenuItemTypeRepository>, IRepository<MenuItemTypeRepository>
    {
        public MenuItemTypeRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
