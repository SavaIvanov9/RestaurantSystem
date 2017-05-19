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
        private ICollection<Component> components;

        public MenuItem()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.components = new HashSet<Component>();
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
        public MenuItemType MenuType { get; set; }

        [Required]
        public long MenuTypeId { get; set; }

        public string Recipe { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Component> Components
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
