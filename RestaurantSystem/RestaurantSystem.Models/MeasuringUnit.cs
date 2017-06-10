namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MeasuringUnit
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<Product> products;

        public MeasuringUnit()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.products = new HashSet<Product>();
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

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                value = this.products;
            }
        }
    }
}

