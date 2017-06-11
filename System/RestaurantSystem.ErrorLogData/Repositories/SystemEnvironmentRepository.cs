namespace RestaurantSystem.ErrorLogData.Repositories
{
    using RestaurantSystem.ErrorLogData.Abstraction;
    using RestaurantSystem.ErrorLogData.Models;
    using RestaurantSystem.ErrorLogData.Repositories.Abstraction;

    public class SystemEnvironmentRepository : GenericRepository<SystemEnvironment>, IRepository<SystemEnvironment>
    {
        public SystemEnvironmentRepository(IErrorDbContext context)
        : base(context)
        {

        }
    }
}