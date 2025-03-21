using Dapperempdetails.Model;
using Dapperempdetails.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.Cache;

namespace Dapperempdetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    #region Employee repo with constructor interact with the data layer
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository,ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }


        #region CreateNewEmployee
        [HttpPost("CreateNewEmployee")]
    public IActionResult Create(Employee employee)
        {
            if (employee.Age < 0)
            {
                ModelState.AddModelError("Age","Job needs to be +ve");
               return BadRequest(ModelState);
            }
            else
            {
                _logger.LogInformation("Creating a employee");
                var result = _employeeRepository.AddEmployee(employee);
                return result.Status == "Success" ? Ok(result) : BadRequest(ModelState);
            }
           
        }
        #endregion
        #region GetAllEmployees
        [HttpGet("GetAllEmployees")]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            else
            {
                var result = _employeeRepository.GetAllEmployees();
                return Ok(result);
            }
         
        }
        #endregion
        #region GetEmployeeByID
        [HttpGet("GetEmployeeByID")]
        public IActionResult Details(int id)
        {
            if (id < 0)
            {
                _logger.LogError("ID is invalid");
                return BadRequest("Invalid employee ID.");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("BadRequest");
                return BadRequest(ModelState);
            }
            else
            {
                var result = _employeeRepository.GetbyEmployeeID(id);
                return Ok(result);

            }

        }
        #endregion
        #region Update Employee
        [HttpPut("UpdateEmployee")]
        public IActionResult Update(Employee employee)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            else
            {
                var result =  _employeeRepository.UpdateEmployee(employee);
                return result.Status == "Success" ? Ok(result) : BadRequest(ModelState) ;

            }
           
        }
        #endregion
        #region Delete Employee

        [HttpDelete("DeleteByEmployeeID")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                _logger.LogError("invalid id");
                return BadRequest("Invalid employee ID.");
            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            else
            {
                var result = _employeeRepository.DeleteEmployee(id);
                return Ok(result);
            }
               
        }
        #endregion
    }
}
#endregion