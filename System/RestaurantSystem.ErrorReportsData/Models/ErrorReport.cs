namespace RestaurantSystem.ErrorReportsData.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ErrorReport
    {
        private DateTime createdOn;
        private bool isDeleted;

        public ErrorReport()
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
    }
}
