using EXAM.CRUD.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EXAM.CRUD.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int StockQuantity { get; set; }
    }
}
