namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Waiter
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<Sale> sales;
        private ICollection<Waiter> waiters;

        public Waiter()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.sales = new HashSet<Sale>();
            this.waiters = new HashSet<Waiter>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [ForeignKey("Manager")]
        public long? ManagerId { get; set; }

        public virtual Waiter Manager { get; set; }

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

        public virtual ICollection<Sale> Sales
        {
            get
            {
                return this.sales;
            }

            set
            {
                this.sales = value;
            }
        }

        public virtual ICollection<Waiter> Waiters
        {
            get
            {
                return this.waiters;
            }

            set
            {
                this.waiters = value;
            }
        }
    }
}
