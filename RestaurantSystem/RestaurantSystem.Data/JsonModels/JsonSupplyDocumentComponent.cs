namespace RestaurantSystem.Data.JsonModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class JsonSupplyDocumentComponent
    {
        private DateTime createdOn;
        private bool isDeleted;

        public JsonSupplyDocumentComponent()
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

        public decimal Price { get; set; }

        [JsonIgnore]
        public virtual long SupplyDocumentId { get; set; }

        [JsonIgnore]
        public virtual JsonSupplyDocument SupplyDocument { get; set; }

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


