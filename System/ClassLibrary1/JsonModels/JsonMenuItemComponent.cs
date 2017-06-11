namespace RestaurantSystem.JsonModels.JsonModels
{
    using Newtonsoft.Json;
    using System;

    public class JsonMenuItemComponent
    {
        private DateTime createdOn;
        private bool isDeleted;
        private JsonMenuItem menuItem;

        public JsonMenuItemComponent()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
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

        [JsonIgnore]
        public virtual long ProductId { get; set; }

        public JsonProduct Product { get; set; }

        public decimal Quantity { get; set; }

        [JsonIgnore]
        public virtual long MenuItemId { get; set; }


        [JsonIgnore]
        public virtual JsonMenuItem MenuItem
        {
            get
            {
                return this.menuItem;
            }

            set
            {
                this.menuItem = value;
            }
        }
    }
}
