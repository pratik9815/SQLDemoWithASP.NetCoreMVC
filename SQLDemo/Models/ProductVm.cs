using System.ComponentModel.DataAnnotations;

namespace SQLDemo.Models
{
    public class ProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    public class CreateProduct
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }   
        [Required]
        public int CategoryId { get; set; }
    }
}
