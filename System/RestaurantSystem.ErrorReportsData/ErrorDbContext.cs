using RestaurantSystem.ErrorReportsData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ErrorReportsData
{
    public class ErrorDbContext : DbContext
    {
        public ErrorDbContext() : base("RestaurantSystemErrorDb")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<RestaurantSystemDbContext, Configuration>());

            Database.SetInitializer(new DropCreateDatabaseAlways<ErrorDbContext>());
        }

        public virtual IDbSet<ErrorReport> ErrorReports { get; set; }
    }
}

