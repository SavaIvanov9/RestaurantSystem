namespace RestaurantSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<Supplier> suppliers;
        
        public Address()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.suppliers = new HashSet<Supplier>();
        }

        [Key]
        public long Id { get; set; }

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
        [ForeignKey("City")]
        public virtual long CityId { get; set; }

        [Required]
        public virtual City City { get; set; }

        [Required]
        //[MaxLength(5)]
        public short PostCode { get; set; }

        public string Street { get; set; }

        public string ContactName { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Supplier> Suppliers
        {
            get
            {
                return this.suppliers;
            }
            set
            {
                this.suppliers = value;
            }
        }
    }
}
