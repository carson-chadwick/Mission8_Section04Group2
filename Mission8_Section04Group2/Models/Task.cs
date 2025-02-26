using System.ComponentModel.DataAnnotations;

namespace Mission8_Section04Group2.Models
{
    public class Task
    {
        [Key]
        // public int Task {  get; set; }

        public DateTime? DueDate {  get; set; }

        [Required]
        public int Quadrant {  get; set; }

        // [Foreign Key("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // public 

    }
}
