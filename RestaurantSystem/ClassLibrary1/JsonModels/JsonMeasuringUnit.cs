namespace RestaurantSystem.JsonModels.JsonModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class JsonMeasuringUnit
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<JsonProduct> products;

        public JsonMeasuringUnit()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.products = new HashSet<JsonProduct>();
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
        public virtual ICollection<JsonProduct> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                value = this.products;
            }
        }
    }
}

