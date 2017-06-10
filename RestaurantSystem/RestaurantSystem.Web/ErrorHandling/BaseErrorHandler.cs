namespace RestaurantSystem.Web.ErrorHandling
{
    using RestaurantSystem.ErrorLogData;
    using RestaurantSystem.ErrorLogData.Abstraction;

    public abstract class BaseErrorHandler
    {
        private IErrorData _data;

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
            private set
            {
                this._data = value;
            }
        }
    }
}
