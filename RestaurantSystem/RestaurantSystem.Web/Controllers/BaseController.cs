namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Abstraction;

    public abstract class BaseController : Controller
    {
        private IRestaurantSystemData _data;

        public BaseController(IRestaurantSystemData data)
        {
            this._data = data;
        }

        protected IRestaurantSystemData Data
        {
            get
            {
                return this._data;
            }

            private set
            {
                this._data = value;
            }
        }
    }
}
