using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class ProductModal
    {
        [Key]
        public int SN { get; set; }
        [Required]
        public string? Product { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Range(minimum:2000,maximum:2025)]
        public int Created { get; set; }
    }
}
