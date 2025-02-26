using System.ComponentModel.DataAnnotations;


namespace Mission8_Section04Group2.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }


        [Required]
        public string? CategoryName {  get; set; }

    }
}
