namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SupplyDocument
    {
        private DateTime createdOn;
        private bool isDeleted;

        private ICollection<SupplyDocumentComponent> supplyDocumentComponents;

        public SupplyDocument()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.supplyDocumentComponents = new HashSet<SupplyDocumentComponent>();
        }

        [Key]
        public long Id { get; set; }

        //[Required]
        [ForeignKey("RestaurantBranch")]
        public virtual long? RestaurantBranchId { get; set; }

        public virtual RestaurantBranch RestaurantBranch { get; set; }

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
        public long ReferenceNumber { get; set; }

        [Required]
        public DateTime DocumentDate { get; set; }

        [Required]
        [ForeignKey("Supplier")]
        public virtual long SupplierId { get; set; }

        [Required]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<SupplyDocumentComponent> SupplyDocumentComponents
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

