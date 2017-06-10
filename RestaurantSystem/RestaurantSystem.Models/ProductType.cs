using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Models
{
    public class ProductType
    {
        private DateTime createdOn;
        private bool isDeleted;
        //private ICollection<Product> products;

        public ProductType()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            //this.products = new HashSet<Product>();
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

        public string ProductTypeCode { get; set; }

        //public virtual ICollection<Product> Products
        //{
        //    get
        //    {
        //        return this.products;
        //    }

        //    set
        //    {
        //        value = this.products;
        //    }
        //}
    }
}
