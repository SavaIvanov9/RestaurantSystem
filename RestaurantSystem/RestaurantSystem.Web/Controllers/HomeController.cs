namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Abstraction;
    using System.Linq;

    public class HomeController : BaseController
    {
        public HomeController(IRestaurantSystemData data) :
         base(data)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            //ViewData["Message"] = "Your application description page.";

            var count = this.Data.Address
                .All()
                .ToList()
                .Count;

            ViewData["Message"] = count;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
