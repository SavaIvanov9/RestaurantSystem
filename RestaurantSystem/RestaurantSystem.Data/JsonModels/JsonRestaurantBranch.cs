using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RestaurantSystem.Data.JsonModels
{
    public class JsonRestaurantBranch
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<JsonSale> sales;
        private ICollection<JsonStoredProduct> storedProducts;

        public JsonRestaurantBranch()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.sales = new HashSet<JsonSale>();
            this.storedProducts = new HashSet<JsonStoredProduct>();
        }

        [JsonIgnore]
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public DateTime CreatedOn
        {
            get
            {
                return this.createdOn;
            }
            set
            {
                this.createdOn = value;
            }
        }

        [JsonIgnore]
        public DateTime? ModifiedOn { get; set; }

        [JsonIgnore]
        public bool IsDeleted
        {
            get
            {
                return this.isDeleted;
            }
            set
            {
                this.isDeleted = value;
            }
        }

        public virtual JsonAddress Address { get; set; }

        [JsonIgnore]
        public long AddressId { get; set; }


        public virtual ICollection<JsonSale> Sales
        {
            get
            {
                return this.sales;
            }

            set
            {
                this.sales = value;
            }
        }

        public virtual ICollection<JsonStoredProduct> StoredProducts
        {
            get
            {
                return this.storedProducts;
            }

            set
            {
                this.storedProducts = value;
            }
        }
    }
}
