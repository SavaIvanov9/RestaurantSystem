namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class MeasuringUnitRepository : GenericRepository<MeasuringUnit>, IRepository<MeasuringUnit>
    {
        public MeasuringUnitRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}

