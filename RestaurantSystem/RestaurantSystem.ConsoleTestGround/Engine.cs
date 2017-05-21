using RestaurantSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ConsoleTestGround
{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("RestaurantSystem.ConsoleTestGround started.");

            var db = new RestaurantSystemDbContext();

            Console.WriteLine(db.Address.ToList().Count);
        }
    }
}
