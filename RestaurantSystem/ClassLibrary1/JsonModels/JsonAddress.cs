namespace RestaurantSystem.JsonModels.JsonModels
{
    using Newtonsoft.Json;
    using System;

    public class JsonAddress
    {
        private DateTime createdOn;
        private bool isDeleted;

        public JsonAddress()
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
        public virtual long CityId { get; set; }

        public JsonCity City { get; set; }

        public short PostCode { get; set; }

        public string Street { get; set; }

        public string ContactName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
