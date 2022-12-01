using Microsoft.AspNetCore.Mvc;
using OrionTek.Business.Services;
using OrionTek.Contracts.Models;
using OrionTek.Entities.Dtos.Creational;
using OrionTek.Repopsitory.Contracts;

namespace OrionTek.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeService;
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeService,
            IEmployeeBusiness employeeBusiness,
            ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _employeeBusiness = employeeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get list of employees
        /// </summary>
        /// <returns>List of employees.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            try
            {
                var result = await _employeeService.Get();
                return Ok(result);
            }

            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Create employee
        /// </summary>
        /// <returns>Employeed created.</returns>
        /// <returns>If some error ocurred.</returns>
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeDTO employeeDTO)
        {
            try
            {
                await _employeeBusiness.Create(employeeDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            try
            {
                var result = await _employeeService.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }

            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _employeeService.Delete(id);
                return Ok();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Employee employee)
        {
            if (employee.Id != id){ return BadRequest(); }
            try
            {
                await _employeeService.Update(employee);
                return Ok();
            }

            catch(Exception ex){
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }
    }
}
