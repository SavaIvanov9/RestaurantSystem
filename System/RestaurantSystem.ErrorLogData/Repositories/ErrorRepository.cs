namespace RestaurantSystem.ErrorLogData.Repositories
{
    using RestaurantSystem.ErrorLogData.Abstraction;
    using RestaurantSystem.ErrorLogData.Models;
    using RestaurantSystem.ErrorLogData.Repositories.Abstraction;

    public class ErrorRepository : GenericRepository<Error>, IRepository<Error>
    {
        public ErrorRepository(IErrorDbContext context)
            : base(context)
        {
        }
    }
}
