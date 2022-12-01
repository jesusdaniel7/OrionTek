using System.ComponentModel.DataAnnotations;

namespace OrionTek.Entities.Dtos.Creational
{
    public class EmployeeDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cellphone { get; set; }
        public List<AddressDTO> Addresses { get; set; }
    }
}
