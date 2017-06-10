namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MenuItemsStore
    {
        private DateTime createdOn;
        private bool isDeleted;

        public MenuItemsStore()
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

        //public decimal Price { get; set; }

        //[Required]
        //[ForeignKey("RestaurantBranch")]
        //public virtual long RestaurantBranchId { get; set; }

        //public virtual RestaurantBranch RestaurantBranch { get; set; }

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




