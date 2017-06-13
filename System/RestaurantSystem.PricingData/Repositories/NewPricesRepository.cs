namespace RestaurantSystem.PricingData.Repositories
{
    using RestaurantSystem.PricingData.Abstraction;
    using RestaurantSystem.PricingData.Models;
    using RestaurantSystem.PricingData.Repositories.Abstraction;

    public class NewPricesRepository : GenericRepository<NewPrices>, IRepository<NewPrices>
    {
        public NewPricesRepository(IPricingDataDbContext context)
            : base(context)
        {
        }
    }
}