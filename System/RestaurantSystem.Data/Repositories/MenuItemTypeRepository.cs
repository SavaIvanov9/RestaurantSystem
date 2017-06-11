namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class MenuItemTypeRepository : GenericRepository<MenuItemType>, IRepository<MenuItemType>
    {
        public MenuItemTypeRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
