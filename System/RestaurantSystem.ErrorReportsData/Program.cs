using RestaurantSystem.ErrorReportsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ErrorReportsData
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ErrorDbContext();

            Console.WriteLine(db.ErrorReports.ToList().Count);

            db.ErrorReports.Add(new ErrorReport
            {
                Name = "1",
                Content = "c1"
            });

            db.SaveChanges();

            Console.WriteLine(db.ErrorReports.ToList().Count);
        }
    }
}
