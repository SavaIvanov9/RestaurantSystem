namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class CityRepository : GenericRepository<City>, IRepository<City>
    {
        public CityRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
