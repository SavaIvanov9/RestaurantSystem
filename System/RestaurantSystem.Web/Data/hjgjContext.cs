using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Models;

namespace RestaurantSystem.Web.Models
{
    public class hjgjContext : DbContext
    {
        public hjgjContext (DbContextOptions<hjgjContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantSystem.Models.Product> Product { get; set; }
    }
}
