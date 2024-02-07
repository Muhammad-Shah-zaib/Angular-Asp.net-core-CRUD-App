using CRUDDotnetApi.Data;
using CRUDDotnetApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace CRUDDotnetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepo _addEmployee;

        public EmployeeController(EmployeeRepo addEmployee)
        {
            this._addEmployee = addEmployee;
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee model)
        {
            await this._addEmployee.AddEmpAsync(model);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            var employeeList = await this._addEmployee.GetAllEmployeesAsync();
            return Ok(employeeList);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employee = await this._addEmployee.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }
        [HttpDelete("{id}")]
        public async Task DeleteEployeeById([FromRoute] int id)
        {
            await this._addEmployee.DeleteEmployeeAsync(id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee model)
        {
            await this._addEmployee.UpdateEmployeeAsync(id, model);
            return Ok(model);
        }
    }
}
