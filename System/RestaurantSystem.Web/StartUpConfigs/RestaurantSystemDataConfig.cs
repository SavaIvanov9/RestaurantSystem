namespace RestaurantSystem.Web.StartUpConfigs
{
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Migrations;
    using System.Data.Entity;

    public class RestaurantSystemDataConfig
    {
        public static void Initizlize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RestaurantSystemDbContext, Configuration>());

            //Database.SetInitializer(new DropCreateDatabaseAlways<RestaurantSystemDbContext>());
        }
    }
}
