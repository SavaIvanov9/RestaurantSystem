namespace RestaurantSystem.Data.Repositories
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Repositories.Abstraction;
    using RestaurantSystem.Models;

    public class SupplyDocumentComponentRepository : GenericRepository<SupplyDocumentComponent>, IRepository<SupplyDocumentComponent>
    {
        public SupplyDocumentComponentRepository(IRestaurantSystemDbContext context)
            : base(context)
        {
        }
    }
}

