
namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class AddressRepository : GenericRepository<AddressRepository>, IRepository<AddressRepository>
    {
        public AddressRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
