using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.JsonModels
{
    public class JsonSupplier
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<JsonSupplyDocument> supplyDocuments;

        public JsonSupplier()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.supplyDocuments = new HashSet<JsonSupplyDocument>();
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

        public virtual JsonAddress Address { get; set; }

        [JsonIgnore]
        public long AddressId { get; set; }

        [JsonIgnore]
        public ICollection<JsonSupplyDocument> SupplyDocuments
        {
            get
            {
                return this.supplyDocuments;
            }
            set
            {
                this.supplyDocuments = value;
            }
        }

    }
}
