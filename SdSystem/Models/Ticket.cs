using System;
using System.ComponentModel.DataAnnotations;

namespace SdSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Department { get; set; }

        public string? Priority { get; set; }
        public string Status { get; set; } = "New";
        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        public string? AssignedTo { get; set; }
        public string? CompletedWork { get; set; }
    }
}
