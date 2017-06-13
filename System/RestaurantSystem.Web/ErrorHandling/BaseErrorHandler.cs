namespace RestaurantSystem.Web.ErrorHandling
{
    using RestaurantSystem.ErrorLogData;
    using RestaurantSystem.ErrorLogData.Abstraction;

    public abstract class BaseErrorHandler
    {
        private readonly IErrorData _data;

        public BaseErrorHandler(IErrorData data)
        {
            this._data = data;
        }

        public BaseErrorHandler()
        {
            this._data = new ErrorData();
        }

        protected IErrorData Data
        {
            get
            {
                return this._data;
            }
        }
    }
}
