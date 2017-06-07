namespace RestaurantSystem.ErrorLogData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SystemEnvironment
    {
        private DateTime createdOn;
        private bool isDeleted;
        private ICollection<Error> errors;

        public SystemEnvironment()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
            this.errors = new HashSet<Error>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

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


        public virtual ICollection<Error> Errors
        {
            get
            {
                return this.errors;
            }
            set
            {
                this.errors = value;
            }
        }
    }
}
