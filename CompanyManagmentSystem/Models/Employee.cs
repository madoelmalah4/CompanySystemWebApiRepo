using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagmentSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        [Required , MaxLength(20)]
        public string Position { get; set; }
        public IList<Project> ? Projects { get; set; }
        public int ? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department ? Department { get; set; }
        public Contract ? Contract { get; set; }

    }
}
