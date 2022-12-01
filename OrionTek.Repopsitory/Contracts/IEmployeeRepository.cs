using OrionTek.Contracts.Models;
using OrionTek.Entities.Dtos.Creational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionTek.Repopsitory.Contracts
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> Get();
        Task<Employee> Get(int Id);
        Task Update(Employee employee);
        Task Delete(int Id);
        Task Create(Employee employee);
    }
}
