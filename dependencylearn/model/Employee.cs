using System.ComponentModel.DataAnnotations;

namespace WebApplication1.model
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } 

        public decimal Salary { get; set; }
    }
}
