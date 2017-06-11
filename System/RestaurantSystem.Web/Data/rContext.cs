using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Models;

namespace RestaurantSystem.Web.Models
{
    public class rContext : DbContext
    {
        public rContext (DbContextOptions<rContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantSystem.Models.Waiter> Waiter { get; set; }
    }
}
