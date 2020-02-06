using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Core.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}