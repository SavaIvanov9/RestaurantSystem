using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSystem.Models
{
    public class RestaurantBranch
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<Sale> sales;
        private ICollection<MenuItem> menuItems;
        private ICollection<Product> products;

        public RestaurantBranch()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(30)]
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
        public virtual Address Address { get; set; }

        [Required]
        [ForeignKey("Address")]
        public long AddressId { get; set; }

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

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }
    }
}
