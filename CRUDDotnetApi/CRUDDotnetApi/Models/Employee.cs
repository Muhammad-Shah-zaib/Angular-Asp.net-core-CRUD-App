using System.ComponentModel.DataAnnotations;

namespace CRUDDotnetApi.Models
{
    public class Employee
    {
        // Creating the properties of the Employee class
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public int phone { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}
