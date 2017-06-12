namespace RestaurantSystem.Web
{
    using Microsoft.AspNetCore.Hosting;
    using RestaurantSystem.Web.StartUpConfigs;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            ErrorLogDataConfig.Initizlize();
            RestaurantSystemDataConfig.Initizlize();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
