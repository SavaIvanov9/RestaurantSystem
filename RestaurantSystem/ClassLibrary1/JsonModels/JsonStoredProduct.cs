namespace RestaurantSystem.JsonModels.JsonModels
{
    using Newtonsoft.Json;
    using System;

    public class JsonStoredProduct
    {
        private DateTime createdOn;
        private bool isDeleted;

        public JsonStoredProduct()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
        }

        [JsonIgnore]
        public long Id { get; set; }

        [JsonIgnore]
        public virtual long ProductId { get; set; }

        public virtual JsonProduct Product { get; set; }

        public decimal Quantity { get; set; }

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



