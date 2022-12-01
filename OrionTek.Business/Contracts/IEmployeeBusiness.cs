using OrionTek.Entities.Dtos.Creational;

namespace OrionTek.Business.Services
{
    public interface IEmployeeBusiness
    {
        Task Create(EmployeeDTO employeeDTO);
    }
}
