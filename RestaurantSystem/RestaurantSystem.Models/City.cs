namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<Address> addresses;

        public City()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.addresses = new HashSet<Address>();
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

        public ICollection<Address> Addresses
        {
            get
            {
                return this.addresses;
            }

            set
            {
                value = this.addresses;
            }
        }
    }
}

