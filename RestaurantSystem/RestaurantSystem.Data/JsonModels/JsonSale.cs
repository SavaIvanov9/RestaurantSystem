using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.JsonModels
{
    public class JsonSale   //TODO: Sales price - to override the sales price in MenuItem
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<JsonSaleComponent> saleComponents;

        public JsonSale()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.saleComponents = new HashSet<JsonSaleComponent>();
        }

        [JsonIgnore]
        public long Id { get; set; }

        [JsonIgnore]
        public virtual long RestaurantBranchId { get; set; }

        [JsonIgnore]
        public virtual JsonRestaurantBranch RestaurantBranch { get; set; }


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

        public byte TableNumber { get; set; }

        public virtual JsonWaiter Waiter { get; set; }

        [JsonIgnore]
        public long WaiterId { get; set; }

        public virtual ICollection<JsonSaleComponent> SaleComponents
        {
            get
            {
                return this.saleComponents;
            }

            set
            {
                this.saleComponents = value;
            }
        }

    }
}
