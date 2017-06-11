namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class SupplierRepository : GenericRepository<Supplier>, IRepository<Supplier>
    {
        public SupplierRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}
