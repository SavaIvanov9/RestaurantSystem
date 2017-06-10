namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MenuItem
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<MenuItemComponent> components;

        public MenuItem()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.components = new HashSet<MenuItemComponent>();
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
        public virtual MenuItemType MenuItemType { get; set; }

        [Required]
        [ForeignKey("MenuItemType")]
        public long MenuItemTypeId { get; set; }

        public string Recipe { get; set; }

        [Required]
        public decimal CostPrice { get; set; }

        [Required]
        public decimal SalesPrice { get; set; }

        public virtual ICollection<MenuItemComponent> Components
        {
            get
            {
                return this.components;
            }
            set
            {
                this.components = value;
            }
        }
    }
}
