namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SaleComponent
    {
        private DateTime createdOn;
        private bool isDeleted;

        public SaleComponent()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("MenuItem")]
        public virtual long MenuItemId { get; set; }

        [Required]
        public virtual MenuItem MenuItem { get; set; }

        public decimal Quantity { get; set; }

        //public decimal SalesPrice { get; set; }

        [Required]
        [ForeignKey("Sale")]
        public virtual long SaleId { get; set; }

        public virtual Sale Sale { get; set; }

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



