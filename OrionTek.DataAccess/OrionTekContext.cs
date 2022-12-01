using Microsoft.EntityFrameworkCore;
using OrionTek.Contracts.Models;

namespace OrionTek.DataAccess
{
    public class OrionTekContext : DbContext
    {
        public OrionTekContext(DbContextOptions<OrionTekContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Address> Address { get; set; }
    }
}

