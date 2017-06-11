namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class SupplyDocumentRepository : GenericRepository<SupplyDocument>, IRepository<SupplyDocument>
    {
        public SupplyDocumentRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}

