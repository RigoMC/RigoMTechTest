using Microsoft.EntityFrameworkCore;
using MTechTestAPI.Models;

namespace MTechTestAPI.Repositories
{
    public class MTechTestIMDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public MTechTestIMDb(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public List<Employee> GetEmployeesOrderedByBornDate()
        {
            return Employees.OrderBy(e => e.BornDate).ToList();
        }

        public List<Employee> GetEmployeesWhoHave(string nameFilter = null)
        {
            IQueryable<Employee> query = Employees;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(e => e.Name.Contains(nameFilter));
            }

            return query.OrderBy(e => e.BornDate).ToList();
        }
    }
}
