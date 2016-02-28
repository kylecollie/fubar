using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fubar.ViewModels
{
    public class TicketViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Summary { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; } = 1;
        public int SeverityId { get; set; } = 4;
        public int PriorityId { get; set; } = 1;
        public int? ResolutionId { get; set; } = null;
        public int StatusId { get; set; } = 1;
        public string Version { get; set; }
        public int ProductId { get; set; } = 3;
        public string StepsToReproduce { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
    }
}