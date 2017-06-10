namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class MenuItemsStoreRepository : GenericRepository<MenuItemsStore>, IRepository<MenuItemsStore>
    {
        public MenuItemsStoreRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}

