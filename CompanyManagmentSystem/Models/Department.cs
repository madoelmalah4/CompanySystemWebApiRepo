namespace CompanyManagmentSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Employee> ? Employees { get; set; }
    }
}
