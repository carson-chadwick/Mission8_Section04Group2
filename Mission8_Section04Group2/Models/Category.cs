using System.ComponentModel.DataAnnotations;


namespace Mission8_Section04Group2.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Category {  get; set; }
    }
}
