using Microsoft.EntityFrameworkCore;
using OrionTek.Contracts.Models;
using OrionTek.DataAccess;
using OrionTek.Repopsitory.Contracts;

namespace OrionTek.Repopsitory.Implementations
{
    public class EmployeeService : IEmployeeRepository
    {
        private readonly OrionTekContext _context;

        public EmployeeService(OrionTekContext context)
        {
            _context = context;
        }
        public async Task Create(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        { 
            _context.Employee.Remove(new Employee { Id = Id});
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<Employee>> Get()
        {
            return await _context.Employee
                    .Include(x => x.Addresses)
                    .ToListAsync();
        }

        public async Task<Employee> Get(int Id)
        {
            return await _context.Employee
                    .Include(x => x.Addresses)
                    .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }
    }
}
