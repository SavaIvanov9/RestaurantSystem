namespace RestaurantSystem.ErrorLogData.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Error
    {
        private DateTime createdOn;
        private bool isDeleted;

        public Error()
        {
            this.createdOn = DateTime.Now;
            this.isDeleted = false;
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

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
        [ForeignKey("SystemEnvironment")]
        public virtual long SystemEnvironmentId { get; set; }

        public virtual SystemEnvironment SystemEnvironment { get; set; }
    }
}
