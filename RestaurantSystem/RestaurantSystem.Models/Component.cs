namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Component
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<MenuItem> menuItems;

        public Component()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.menuItems = new HashSet<MenuItem>();
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
        public string ProductTypeCode { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        public virtual ICollection<MenuItem> MenuItems
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
