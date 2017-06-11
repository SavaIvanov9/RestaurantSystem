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
        private ICollection<StoredProduct> storedProducts;

        public RestaurantBranch()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.sales = new HashSet<Sale>();
            this.storedProducts = new HashSet<StoredProduct>();
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

        //[Required]
        //public virtual StoredProduct ProductsStore { get; set; }

        //[Required]
        //[ForeignKey("ProductsStore")]
        //public long ProductsStoreId { get; set; }

        //[Required]
        //public virtual MenuItemsStore MenuItemsStore { get; set; }

        //[Required]
        //[ForeignKey("MenuItemsStore")]
        //public long MenuItemsStoreId { get; set; }

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

        public virtual ICollection<StoredProduct> StoredProducts
        {
            get
            {
                return this.storedProducts;
            }

            set
            {
                this.storedProducts = value;
            }
        }
    }
}
