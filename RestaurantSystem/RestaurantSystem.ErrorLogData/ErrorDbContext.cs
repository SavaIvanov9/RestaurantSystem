namespace RestaurantSystem.ErrorLogData
{
    using RestaurantSystem.ErrorLogData.Abstraction;
    using RestaurantSystem.ErrorLogData.Migrations;
    using RestaurantSystem.ErrorLogData.Models;
    using System.Data.Entity;

    public class ErrorDbContext : DbContext, IErrorDbContext
    {
        public ErrorDbContext() : base("RestaurantSystemErrorData")
        {
            Database.SetInitializer(
               new MigrateDatabaseToLatestVersion<ErrorDbContext, Configuration>());

            //Database.SetInitializer(new DropCreateDatabaseAlways<ErrorDbContext>());
        }

        public IDbSet<Error> Error { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
