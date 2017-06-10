namespace RestaurantSystem.Data.JsonModels
{
    using Newtonsoft.Json;
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class JsonCity
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<JsonAddress> addresses;

        public JsonCity()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.addresses = new HashSet<JsonAddress>();
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
        public ICollection<JsonAddress> Addresses
        {
            get
            {
                return this.addresses;
            }

            set
            {
                value = this.addresses;
            }
        }
    }
}

