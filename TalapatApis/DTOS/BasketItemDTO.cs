using System.ComponentModel.DataAnnotations;

namespace TalapatApis.DTOS
{
    public class BasketItemDTO
    {

        [Required]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string PictureUrl { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage ="Price can't be zero")]
        public decimal Price { get; set; }
        [Required]

        public string Brand { get; set; }
        [Required]

        public string Type { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be 1 at least")]

        public int Quantity { get; set; }
    }
}