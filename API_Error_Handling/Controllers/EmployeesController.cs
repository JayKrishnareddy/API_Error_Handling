using Microsoft.AspNetCore.Mvc;
using static API_Error_Handling.CustomException;

namespace API_Error_Handling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred");

                // Return a generic error response
                return StatusCode(500, "An unexpected error occurred, Please try again later.");
            }
        }
        [HttpGet(nameof(GetEmployeeSalary))]
        public IActionResult GetEmployeeSalary()
        {
            try
            {
                CustomException customException = new();
                customException.UpdateEmployeeSalary(1, -1000); // Invalid salary
                return Ok();
            }
            catch (InvalidSalaryException ex)
            {
                _logger.LogError("Error updating salary: " + ex.Message);
                return StatusCode(403, "Please enter a valid positive salary.");
            }
        }
    }
}
