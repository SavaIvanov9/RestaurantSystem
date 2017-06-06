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
using RestaurantSystem.ErrorLogData;
using RestaurantSystem.ErrorLogData.Models;

namespace RestaurantSystem.TestGround
{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("RestaurantSystem.TestGround started.");
            //TestData();
            TestErrorDb();
        }

        public void TestData()
        {
            var db = new RestaurantSystemData();

            //db.Waiters.Add(new Waiter
            //{
            //    Name = "1"
            //});

            //db.SaveChanges();
            Console.WriteLine(db.Addresses.All().ToList().Count);
        }

        public void TestErrorDb()
        {
            Console.WriteLine("RestaurantSystem.TestGround started.");

            var db = new ErrorDbContext();

            //db.Error.Add(new Error
            //{
            //    Content = "1"
            //});

            //db.SaveChanges();

            Console.WriteLine(db.Error.ToList().Count);

            var error = db.Error.FirstOrDefault();

            Console.WriteLine(error.Name);
            Console.WriteLine(error.Name);
            Console.WriteLine(error.Content);
        }
    }
}
