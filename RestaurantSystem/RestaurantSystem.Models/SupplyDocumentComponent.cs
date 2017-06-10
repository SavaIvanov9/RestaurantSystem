namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SupplyDocumentComponent
    {
        private DateTime createdOn;
        private bool isDeleted;

        public SupplyDocumentComponent()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Product")]
        public virtual long ProductId { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        [Required]
        [ForeignKey("SupplyDocument")]
        public virtual long SupplyDocumentId { get; set; }

        public virtual SupplyDocument SupplyDocument { get; set; }

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

    }
}


