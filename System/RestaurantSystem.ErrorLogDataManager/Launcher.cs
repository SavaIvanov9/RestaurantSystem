namespace RestaurantSystem.ErrorLogDataManager
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var engine = new ErrorLogDataManagerEngine();
            engine.Start();
        }
    }
}
