namespace RestaurantSystem.JsonModels.JsonModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class JsonWaiter
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<JsonSale> sales;

        public JsonWaiter()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.sales = new HashSet<JsonSale>();
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

        [JsonIgnore]
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
    }
}
