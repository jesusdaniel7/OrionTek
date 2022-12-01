using AutoMapper;
using OrionTek.Business.Services;
using OrionTek.Contracts.Models;
using OrionTek.Entities.Dtos.Creational;
using OrionTek.Repopsitory.Contracts;

namespace OrionTek.Business.Implementations
{
    public class EmployeeBusinessService : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeBusinessService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task Create(EmployeeDTO employeeDTO)
        {
            var addres = _mapper.Map<List<Address>>(employeeDTO.Addresses);
            var employe = _mapper.Map<Employee>(employeeDTO);
            employe.Addresses = addres;
            await _employeeRepository.Create(employe);
        }

    }
}
