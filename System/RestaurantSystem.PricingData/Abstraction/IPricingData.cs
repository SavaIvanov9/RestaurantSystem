namespace RestaurantSystem.PricingData.Abstraction
{
    using RestaurantSystem.PricingData.Repositories;

    public interface IPricingData
    {
        NewPricesRepository NewPricesRepository { get; }

        int SaveChanges();
    }
}
