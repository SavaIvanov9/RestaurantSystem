namespace RestaurantSystem.Web.StartUpConfigs
{
    using RestaurantSystem.ErrorLogData;
    using RestaurantSystem.ErrorLogData.Migrations;
    using System.Data.Entity;

    public class ErrorLogDataConfig
    {
        public static void Initizlize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ErrorDbContext, Configuration>());

            //Database.SetInitializer(new DropCreateDatabaseAlways<ErrorDbContext>());
        }
    }
}
