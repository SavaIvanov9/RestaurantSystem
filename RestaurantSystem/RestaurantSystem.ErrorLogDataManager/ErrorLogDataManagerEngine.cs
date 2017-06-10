namespace RestaurantSystem.ErrorLogDataManager
{
    using RestaurantSystem.ErrorLogData;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RestaurantSystem.ErrorLogData.Migrations;
    using RestaurantSystem.ErrorLogData.Abstraction;
    using RestaurantSystem.ErrorLogData.Models;
    using RestaurantSystem.Infrastructure;
    using RestaurantSystem.Infrastructure.Constants;

    public class ErrorLogDataManagerEngine
    {
        private IErrorData _data;

        public ErrorLogDataManagerEngine()
        {
            this._data = new ErrorData();

            ConfigureDb();
        }

        public void Start()
        {
            //ShortDisplayDbStatus();
            //InsertTestData();

            DisplayDbStatus();
        }

        private void ConfigureDb()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ErrorDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<ErrorDbContext>());
        }

        private void InsertTestData()
        {
            var system = this._data.SystemEnvironmentRepository
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .FirstOrDefault();

            if (system == null)
            {
                var restaurantSystemWebMvc = new SystemEnvironment
                {
                    Name = SystemEnvironments.RestaurantSystemWebMvc.ToString(),
                    Description = GlobalConstants.RestaurantSystemDescription,
                };

                this._data.SystemEnvironmentRepository
                    .Add(restaurantSystemWebMvc);

                this._data.SaveChanges();

                restaurantSystemWebMvc.Errors.Add(new Error
                {
                    Name = "Test message",
                    Content = "Test content",

                });

                this._data.SystemEnvironmentRepository
                    .Update(restaurantSystemWebMvc);
            }
            else
            {
                this._data.ErrorRepository
                    .Add(new Error
                    {
                        Name = "Test message",
                        Content = "Test content",
                        SystemEnvironment = system,
                        SystemEnvironmentId = system.Id
                    });

                this._data.SystemEnvironmentRepository
                    .Update(system);
            }

            this._data.SaveChanges();
        }

        private void ShortDisplayDbStatus()
        {
            var systems = this._data.SystemEnvironmentRepository
                .All()
                .ToList();

            var errors = this._data.ErrorRepository
                .All()
                .ToList();

            Console.WriteLine($"Systems count: {systems.Count}");
            Console.WriteLine($"Errors count: {errors.Count}");
        }

        private void DisplayDbStatus()
        {
            var systems = this._data.SystemEnvironmentRepository
                .All()
                .ToList();

            var errors = this._data.ErrorRepository
                .All()
                .ToList();

            Console.WriteLine($"Systems count: {systems.Count}");
            Console.WriteLine($"Errors count: {errors.Count}");

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=| Systems |=-=-=-=--=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine();

            foreach (var system in systems)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"System Id: {system.Id}");
                Console.WriteLine($"System Name: {system.Name}");
                Console.WriteLine($"System Description: {system.Description}");
                Console.WriteLine($"System Created On: {system.CreatedOn}");
                Console.WriteLine($"System IsDeleted: {system.IsDeleted}");
                Console.WriteLine($"System Errors Count: {system.Errors.Count}");
                Console.WriteLine();
                Console.WriteLine("Errors:");
                Console.WriteLine();

                DisplayErrors(system.Errors.ToList(), "   ");
            }
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine();
            Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+| Errors |+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine();

            DisplayErrors(errors, "");

            Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
        }

        private void DisplayErrors(List<Error> errors, string align)
        {
            foreach (var error in errors)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"{align}Error id: {error.Id}");
                Console.WriteLine($"{align}Error Name: {error.Name}");
                Console.WriteLine($"{align}Error System Id: {error.SystemEnvironmentId}/{error.SystemEnvironment.Id}");
                Console.WriteLine($"{align}Error Created On: {error.CreatedOn}");
                Console.WriteLine($"{align}Error IsDeleted: {error.IsDeleted}");
                Console.WriteLine($"{align}Error Content: {error.Content}");
                Console.WriteLine();
            }
        }
    }
}
