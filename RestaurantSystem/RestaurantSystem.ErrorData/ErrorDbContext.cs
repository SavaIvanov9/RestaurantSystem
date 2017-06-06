namespace RestaurantSystem.ErrorData
{
    using RestaurantSystem.ErrorData.Abstraction;
    using RestaurantSystem.ErrorData.Migrations;
    using RestaurantSystem.ErrorData.Models;
    using System.Data.Entity;

    public class ErrorDbContext : DbContext, IErrorDbContext
    {
        public ErrorDbContext() : base("RestaurantSystemErrorData")
        {
            Database.SetInitializer(
               new MigrateDatabaseToLatestVersion<ErrorDbContext, Configuration>());

            //Database.SetInitializer(new DropCreateDatabaseAlways<RestaurantSystemDbContext>());
        }

        public IDbSet<Error> Error { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
