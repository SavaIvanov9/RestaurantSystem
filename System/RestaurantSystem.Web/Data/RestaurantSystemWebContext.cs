using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Models;

namespace RestaurantSystem.Web.Models
{
    public class RestaurantSystemWebContext : DbContext
    {
        public RestaurantSystemWebContext (DbContextOptions<RestaurantSystemWebContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantSystem.Models.SupplyDocument> SupplyDocument { get; set; }
    }
}
