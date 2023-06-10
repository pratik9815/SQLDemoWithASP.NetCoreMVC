using System.ComponentModel.DataAnnotations;

namespace SQLDemo.Models
{
    public class CategoryVm
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; } 
    }
    public class CreateCategory
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
