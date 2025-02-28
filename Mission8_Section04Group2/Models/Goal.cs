using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mission8_Section04Group2.Models
{
    public class Goal
    {
        [Key]

        public int GoalId { get; set; }


        [Required]
        public string? GoalName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Required]
        public int Quadrant {  get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool Completed { get; set; } = false;

    }
}
