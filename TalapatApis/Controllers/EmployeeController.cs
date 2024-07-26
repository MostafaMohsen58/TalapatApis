using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talapat.Core.Entities;
using Talapat.Core.Repositories;
using Talapat.Core.specifications;

namespace TalapatApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IgenericRepository<Employee> _employeeRepo;

        public ApiController(IgenericRepository<Employee> EmployeeRepo)
        {
            _employeeRepo = EmployeeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var Spec = new EmployeeAndDepartmentSpecifications();
            var Employees = await _employeeRepo.GetAllWithSpecAsync(Spec);
            return Ok(Employees);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Employee>> GetEmployeeById (int id)
        {
            var Spec= new EmployeeAndDepartmentSpecifications(id);

            var Employee = await _employeeRepo.GetByIdWithSpecAsync(Spec);
            return Ok(Employee);
        }

    }
}
