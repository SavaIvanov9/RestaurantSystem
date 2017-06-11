namespace RestaurantSystem.JsonModels.JsonModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class JsonProduct
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<JsonSupplyDocumentComponent> supplyDocumentComponents;
        private ICollection<JsonMenuItemComponent> menuItemComponents;

        public JsonProduct()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.supplyDocumentComponents = new HashSet<JsonSupplyDocumentComponent>();
            this.menuItemComponents = new HashSet<JsonMenuItemComponent>();
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

        public virtual JsonMeasuringUnit MeasuringUnit { get; set; }

        [JsonIgnore]
        public long MeasuringUnitId { get; set; }

        public decimal AveragePrice { get; set; }

        [JsonIgnore]
        public virtual ICollection<JsonSupplyDocumentComponent> SupplyDocumentComponents
        {
            get
            {
                return this.supplyDocumentComponents;
            }
            set
            {
                this.supplyDocumentComponents = value;
            }
        }

        [JsonIgnore]
        public virtual ICollection<JsonMenuItemComponent> MenuItemComponents
        {
            get
            {
                return this.menuItemComponents;
            }
            set
            {
                this.menuItemComponents = value;
            }
        }
    }
}
