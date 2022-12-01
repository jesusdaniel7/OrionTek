using System.ComponentModel.DataAnnotations;

namespace OrionTek.Entities.Dtos.Creational
{
    public class AddressDTO
    {
        [Required]
        public string State { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
