namespace RestaurantSystem.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.DataImporter.SupplyDocumentImporter;
    using RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction;
    using RestaurantSystem.ErrorLogData;
    using RestaurantSystem.ErrorLogData.Abstraction;
    using RestaurantSystem.JsonManaging;
    using RestaurantSystem.PDFManaging;
    using RestaurantSystem.Services;
    using RestaurantSystem.Services.Abstraction;
    using RestaurantSystem.Web.ErrorHandling;
    using RestaurantSystem.Web.StartUpConfigs;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRestaurantSystemData, RestaurantSystemData>();
            services.AddTransient<IErrorData, ErrorData>();

            services.AddTransient<IJsonProcessingService, JsonProcessingService>();
            services.AddTransient<IJsonManager, JsonManager>();

            services.AddTransient<IProductsPDFManager, ProductsPDFManager>();
            
            services.AddTransient<ISupplyDocumentDataSeeder, SupplyDocumentDataSeeder>();
            
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCustomErrorHandler();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
