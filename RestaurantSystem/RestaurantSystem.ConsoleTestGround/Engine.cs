using RestaurantSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using RestaurantSystem.Data.Migrations;
using RestaurantSystem.Models;

namespace RestaurantSystem.ConsoleTestGround
{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("RestaurantSystem.ConsoleTestGround started.");
            
            var db = new RestaurantSystemData();

            db.Waiters.Add(new Waiter
            {
                Name = "1"
            });

            db.SaveChanges();
            Console.WriteLine(db.Addresses.All().ToList().Count);
        }
    }
}
