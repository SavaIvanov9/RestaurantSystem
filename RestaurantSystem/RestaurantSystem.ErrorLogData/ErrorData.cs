namespace RestaurantSystem.ErrorLogData
{
    using RestaurantSystem.ErrorLogData.Abstraction;
    using RestaurantSystem.ErrorLogData.Models;
    using RestaurantSystem.ErrorLogData.Repositories;
    using RestaurantSystem.ErrorLogData.Repositories.Abstraction;
    using System;
    using System.Collections.Generic;

    public class ErrorData : IErrorData
    {
        private readonly IErrorDbContext _context;
        private readonly IDictionary<Type, object> _repositories;

        public ErrorData()
            : this(new ErrorDbContext())
        {
        }

        public ErrorData(IErrorDbContext context)
        {
            this._context = context;
            this._repositories = new Dictionary<Type, object>();
        }

        public ErrorRepository ErrorRepository =>
            (ErrorRepository)this.GetRepository<Error>();

        public SystemEnvironmentRepository SystemEnvironmentRepository =>
            (SystemEnvironmentRepository)this.GetRepository<SystemEnvironment>();

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var repositoryType = typeof(T);

            if (!this._repositories.ContainsKey(repositoryType))
            {
                var type = typeof(GenericRepository<T>);

                this.SetType(repositoryType, ref type);

                this._repositories.Add(repositoryType, Activator.CreateInstance(type, this._context));
            }

            return (IRepository<T>)this._repositories[repositoryType];
        }

        private void SetType(Type repositoryType, ref Type type)
        {
            if (repositoryType.IsAssignableFrom(typeof(Error)))
                type = typeof(ErrorRepository);
            else if (repositoryType.IsAssignableFrom(typeof(SystemEnvironment)))
                type = typeof(SystemEnvironmentRepository);
        }
    }
}
