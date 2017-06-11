namespace RestaurantSystem.ErrorLogData.Abstraction
{
    using RestaurantSystem.ErrorLogData.Repositories;

    public interface IErrorData
    {
        ErrorRepository ErrorRepository { get; }

        SystemEnvironmentRepository SystemEnvironmentRepository { get; }

        int SaveChanges();
    }
}
