using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Models
{
    public class Sale   //TODO: Sales price - to override the sales price in MenuItem
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<SaleComponent> saleComponents;

        public Sale()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.saleComponents = new HashSet<SaleComponent>();
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
        public byte TableNumber { get; set; }

        [Required]
        public virtual Waiter Waiter { get; set; }

        [Required]
        [ForeignKey("Waiter")]
        public long WaiterId { get; set; }

        public virtual ICollection<SaleComponent> SaleComponents
        {
            get
            {
                return this.saleComponents;
            }

            set
            {
                this.saleComponents = value;
            }
        }

    }
}
