namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class RestaurantBranchRepository : GenericRepository<RestaurantBranch>, IRepository<RestaurantBranch>
    {
        public RestaurantBranchRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
