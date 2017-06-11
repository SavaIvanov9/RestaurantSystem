namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Supplier
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<SupplyDocument> supplyDocuments;

        public Supplier()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.supplyDocuments = new HashSet<SupplyDocument>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

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

        public DateTime? ModifiedOn { get; set; }

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

        [Required]
        public virtual Address Address { get; set; }

        [Required]
        [ForeignKey("Address")]
        public long AddressId { get; set; }

        public ICollection<SupplyDocument> SupplyDocuments
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
