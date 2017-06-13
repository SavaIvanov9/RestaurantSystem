namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<SupplyDocumentComponent> supplyDocumentComponents;
        private ICollection<MenuItemComponent> menuItemComponents;

        public Product()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.supplyDocumentComponents = new HashSet<SupplyDocumentComponent>();
            this.menuItemComponents = new HashSet<MenuItemComponent>();
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
        [ForeignKey("MeasuringUnit")]
        public long MeasuringUnitId { get; set; }

        public virtual MeasuringUnit MeasuringUnit { get; set; }

        [Required]
        public decimal AveragePrice { get; set; }

        public virtual ICollection<SupplyDocumentComponent> SupplyDocumentComponents
        {
            get
            {
                return this.supplyDocumentComponents;
            }
            set
            {
                this.supplyDocumentComponents = value;
            }
        }

        public virtual ICollection<MenuItemComponent> MenuItemComponents
        {
            get
            {
                return this.menuItemComponents;
            }
            set
            {
                this.menuItemComponents = value;
            }
        }
    }
}
