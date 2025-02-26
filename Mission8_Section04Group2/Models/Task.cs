using System.ComponentModel.DataAnnotations;

namespace Mission8_Section04Group2.Models
{
    public class Task
    {
        [Key]
        public int Task {  get; set; }

        public DateTime? DueDate {  get; set; }

        [Required]
        public int Quadrant {  get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool Completed { get; set; } = false;

    }
}
