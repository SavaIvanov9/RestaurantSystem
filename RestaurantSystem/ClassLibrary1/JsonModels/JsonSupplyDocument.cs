namespace RestaurantSystem.JsonModels.JsonModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class JsonSupplyDocument
    {
        private DateTime createdOn;
        private bool isDeleted;

        private ICollection<JsonSupplyDocumentComponent> supplyDocumentComponents;

        public JsonSupplyDocument()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.supplyDocumentComponents = new HashSet<JsonSupplyDocumentComponent>();
        }

        [JsonIgnore]
        public long Id { get; set; }

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

        public long ReferenceNumber { get; set; }

        public DateTime DocumentDate { get; set; }

        [JsonIgnore]
        public virtual long SupplierId { get; set; }

        public virtual JsonSupplier Supplier { get; set; }

        public virtual ICollection<JsonSupplyDocumentComponent> SupplyDocumentComponents
        {
            get
            {
                return this.supplyDocumentComponents;
            }

            set
            {
                value = this.supplyDocumentComponents;
            }
        }
    }
}

