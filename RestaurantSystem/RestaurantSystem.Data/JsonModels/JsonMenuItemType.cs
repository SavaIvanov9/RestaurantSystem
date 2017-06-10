namespace RestaurantSystem.Data.JsonModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class JsonMenuItemType
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<JsonMenuItem> menuItems;

        public JsonMenuItemType()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.menuItems = new HashSet<JsonMenuItem>();
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

        public string MenuItemTypeCode { get; set; }

        [JsonIgnore]
        public virtual ICollection<JsonMenuItem> MenuItems
        {
            get
            {
                return this.menuItems;
            }

            set
            {
                this.menuItems = value;
            }
        }
    }
}
