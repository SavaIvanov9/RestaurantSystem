
namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class Address : GenericRepository<Address>, IRepository<Address>
    {
        public Address(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
