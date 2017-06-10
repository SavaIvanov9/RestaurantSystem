namespace RestaurantSystem.JsonModels.JsonModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class JsonMenuItem
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<JsonMenuItemComponent> components;

        public JsonMenuItem()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.components = new HashSet<JsonMenuItemComponent>();
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

        public virtual JsonMenuItemType MenuItemType { get; set; }

        [JsonIgnore]
        public long MenuItemTypeId { get; set; }

        public string Recipe { get; set; }

        [JsonIgnore]
        public decimal CostPrice { get; set; }

        [JsonIgnore]
        public decimal SalesPrice { get; set; }

        public virtual ICollection<JsonMenuItemComponent> Components
        {
            get
            {
                return this.components;
            }
            set
            {
                this.components = value;
            }
        }
    }
}
