namespace SqlLite.TestGround
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext()
            : base("ItemExpensesDbEntities")
        {
        }

        //public DbSet<Item> Items { get; set; }
    }
}
