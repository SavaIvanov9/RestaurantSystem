namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Abstraction;
    using System;
    using System.Linq;

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

            ViewData["Message"] = "";

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
