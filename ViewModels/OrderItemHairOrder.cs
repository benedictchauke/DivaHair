using System.ComponentModel.DataAnnotations;

namespace DivaHair.ViewModels
{
    public class OrderItemHairOrder
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}