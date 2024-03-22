using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTechTestAPI.Models
{
    [Microsoft.EntityFrameworkCore.Index(nameof(RFC), IsUnique = true)]
    public class Employee
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]{4}\d{6}[A-Z0-9]{3}$", ErrorMessage = "The RFC must have the correct format and length")]
        [MaxLength(13)]
        public string RFC { get; set; }
        [Required]
        public DateTime BornDate { get; set; }
        [Required]
        public EmployeeStatus Status { get; set; }
    }

    public enum EmployeeStatus
    {
        NotSet,
        Active,
        Inactive,
    }
}
