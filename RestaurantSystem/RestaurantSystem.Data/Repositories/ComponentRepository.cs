namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class ComponentRepository : GenericRepository<Component>, IRepository<Component>
    {
        public ComponentRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
