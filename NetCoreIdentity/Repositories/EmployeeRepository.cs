using NetCoreIdentity.Data;
using NetCoreIdentity.Models;
using NetCoreIdentity.Requests;
using System.Threading.Tasks;

namespace NetCoreIdentity.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> AddEmployee(AddEmployeeRequest request);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddEmployee(AddEmployeeRequest request)
        {
            Employee employee = new Employee()
            {
                UserId = request.UserId,
                DateOfBirth = request.DateOfBirth,
                Position = request.Position
            };

            await _context.Employees.AddAsync(employee);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
    }
}
