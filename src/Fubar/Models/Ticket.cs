using System;

namespace Fubar.Models
{
    public class Ticket
    {
        public Ticket()
        {

        }
        public int ID { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        // Foreign key for Category
        public int CategoryId { get; set; }
        //public Category Category { get; set; }

        // Foreign key for Severity
        public int SeverityId { get; set; }
        //public Severity Severity { get; set; }

        // Foreign key for Priority
        public int PriorityId { get; set; }
        //public Priority Priority { get; set; }

        // Foreign key for Resolution
        public int? ResolutionId { get; set; }
        //public Resolution Resolution { get; set; }

        // Foreign key for Status
        public int StatusId { get; set; }
        //public Status Status { get; set; }

        public string Version { get; set; }

        // Foreign key for Product
        public int ProductId { get; set; }
        //public Product Product { get; set; }

        public string StepsToReproduce { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime LastUpdate { get; set; }

        public string UserName { get; set; }
    }
}