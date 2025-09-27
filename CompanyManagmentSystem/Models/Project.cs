using System.ComponentModel.DataAnnotations;

namespace CompanyManagmentSystem.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }
        [Required, MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public IList<Employee> ?  Employees { get; set; }
    }
}
