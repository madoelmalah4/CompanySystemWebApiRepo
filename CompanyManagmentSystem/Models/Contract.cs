namespace CompanyManagmentSystem.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ? EmployeeId { get; set; }
        public Employee ? Employee { get; set; }
    }
}
