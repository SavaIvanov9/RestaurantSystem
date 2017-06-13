namespace RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction
{
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.ErrorLogData;
    using RestaurantSystem.ErrorLogData.Abstraction;
    using RestaurantSystem.ErrorLogData.Models;
    using RestaurantSystem.Infrastructure;
    using RestaurantSystem.Infrastructure.Constants;
    using System;
    using System.Linq;

    public abstract class BaseImporter
    {
        private readonly IErrorData _data = new ErrorData();
        private int saveChangesCount = 50;

        protected void SaveChanges(int count, IRestaurantSystemData db)
        {
            if (count % saveChangesCount == 0)
            {
                for (int i = 0; i <= GlobalConstants.SaveChangesRetryCountIfError; i++)
                {
                    try
                    {
                        var c = db.SaveChanges();
                        break;
                    }
                    catch (Exception exception)
                    {
                        var system = this._data.SystemEnvironmentRepository
                            .All()
                            .Where(x => x.IsDeleted != true
                                && x.Name == SystemEnvironments.RestaurantSystemWebMvc.ToString())
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
                                Name = exception.Message,
                                Content = exception.ToString(),
                            });

                            this._data.SystemEnvironmentRepository
                                .Update(restaurantSystemWebMvc);
                        }
                        else
                        {
                            system.Errors
                                .Add(new Error
                                {
                                    Name = exception.Message,
                                    Content = exception.ToString(),
                                    SystemEnvironmentId = system.Id,
                                    SystemEnvironment = system
                                });

                            this._data.SystemEnvironmentRepository
                                .Update(system);
                        }

                        this._data.SaveChanges();
                    }
                }
            }
        }
    }
}
