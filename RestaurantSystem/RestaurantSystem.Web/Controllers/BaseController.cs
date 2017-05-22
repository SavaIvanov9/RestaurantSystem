namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Abstraction;

    public class BaseController : Controller
    {
        private IRestaurantSystemData data;

        public BaseController(IRestaurantSystemData data)
        {
            this.Data = data;
        }

        protected IRestaurantSystemData Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                this.data = value;
            }
        }
    }

}
