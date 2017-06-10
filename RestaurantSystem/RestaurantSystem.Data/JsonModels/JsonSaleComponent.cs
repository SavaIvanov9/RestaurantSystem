namespace RestaurantSystem.Data.JsonModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class JsonSaleComponent
    {
        private DateTime createdOn;
        private bool isDeleted;

        public JsonSaleComponent()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
        }

        [JsonIgnore]
        public long Id { get; set; }

        [JsonIgnore]
        public virtual long MenuItemId { get; set; }

        public virtual JsonMenuItem MenuItem { get; set; }

        public decimal Quantity { get; set; }

        //public decimal SalesPrice { get; set; }

        [JsonIgnore]
        public virtual long SaleId { get; set; }

        [JsonIgnore]
        public virtual JsonSale Sale { get; set; }

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

    }
}



