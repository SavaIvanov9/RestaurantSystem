namespace RestaurantSystem.Data
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Data.Migrations;
    using RestaurantSystem.Models;
    using System.Data.Entity;

    public class RestaurantSystemDbContext : DbContext, IRestaurantSystemDbContext
    {
        public RestaurantSystemDbContext() : base("RestaurantSystem")
        {
            Database.SetInitializer(
               new MigrateDatabaseToLatestVersion<RestaurantSystemDbContext, Configuration>());

            //Database.SetInitializer(new DropCreateDatabaseAlways<JustSnakeDbContext>());
        }

        public virtual IDbSet<Address> Address { get; set; }
                
        public virtual IDbSet<City> City { get; set; }
                
        public virtual IDbSet<Component> Component { get; set; }
                
        public virtual IDbSet<MenuItem> MenuItem { get; set; }
                
        public virtual IDbSet<MenuItemType> MenuItemType { get; set; }
                
        public virtual IDbSet<Product> Product { get; set; }
                
        public virtual IDbSet<ProductType> ProductType { get; set; }
                
        public virtual IDbSet<RestaurantBranch> RestaurantBranch { get; set; }
                
        public virtual IDbSet<Sale> Sale { get; set; }
                
        public virtual IDbSet<Supplier> Supplier { get; set; }
                
        public virtual IDbSet<Waiter> Waiter { get; set; }
        
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
