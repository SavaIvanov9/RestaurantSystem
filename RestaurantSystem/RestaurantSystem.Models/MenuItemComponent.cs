namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MenuItemComponent
    {
        private DateTime createdOn;
        private bool isDeleted;
        private MenuItem menuItem;

        public MenuItemComponent()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
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
        [ForeignKey("Product")]
        public virtual long ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        [ForeignKey("MenuItem")]
        public virtual long MenuItemId { get; set; }


        public virtual MenuItem MenuItem
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
