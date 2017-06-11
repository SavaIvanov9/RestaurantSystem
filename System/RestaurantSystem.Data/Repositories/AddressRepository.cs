
namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class AddressRepository : GenericRepository<Address>, IRepository<Address>
    {
        public AddressRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
