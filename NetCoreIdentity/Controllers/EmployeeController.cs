using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreIdentity.Data.Const;
using NetCoreIdentity.Repositories;
using NetCoreIdentity.Requests;
using System.Threading.Tasks;

namespace NetCoreIdentity.Controllers
{
    [Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;

        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        // https://localhost:5001/api/v1/employee/create
        // if we didn't sign in firstly this api will not work

        [Route(Routes.Employee.Create)]
        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeRequest request)
        {
            var isCreated = await _employee.AddEmployee(request);
            return Ok(isCreated);
        }
    }
}
