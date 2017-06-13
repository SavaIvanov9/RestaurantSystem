namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.PricingData;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class HomeController : BaseController
    {
        public HomeController(IRestaurantSystemData data) : base(data)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            //var db = new PricingDataDbContext();
            //ViewData["Message"] = db.NewPrices.ToList().Count();

            ViewData["Message"] = Directory.GetCurrentDirectory();

            return View();
        }

        public IActionResult Contact()
        {
            throw new Exception("Test error 1");

            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult TestError()
        {
            throw new Exception("Test error 2");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
