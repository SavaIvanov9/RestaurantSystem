using RestaurantSystem.PricingData.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSystem.PricingData.Repositories;
using RestaurantSystem.PricingData.Models;
using RestaurantSystem.PricingData.Repositories.Abstraction;

namespace RestaurantSystem.PricingData
{
    public class PricingData : IPricingData
    {
        private readonly IPricingDataDbContext _context;
        private readonly IDictionary<Type, object> _repositories;

        public PricingData()
            : this(new PricingDataDbContext())
        {
        }

        public PricingData(IPricingDataDbContext context)
        {
            this._context = context;
            this._repositories = new Dictionary<Type, object>();
        }

        public NewPricesRepository NewPricesRepository =>
            (NewPricesRepository)this.GetRepository<NewPrices>();

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
            if (repositoryType.IsAssignableFrom(typeof(NewPrices)))
                type = typeof(NewPricesRepository);
        }
    }
}
