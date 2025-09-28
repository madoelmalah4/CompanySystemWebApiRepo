using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagmentSystem.Models.DTOs
{
    public class Employee_DTO_Get
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }
    public class Employee_DTO_Post
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }
}
