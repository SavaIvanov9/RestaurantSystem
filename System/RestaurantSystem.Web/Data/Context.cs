using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Models;

namespace RestaurantSystem.Web.Models
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<RestaurantSystem.Models.Sale> Sale { get; set; }
    }
}
