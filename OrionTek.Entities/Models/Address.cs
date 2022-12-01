namespace OrionTek.Contracts.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
    
}
