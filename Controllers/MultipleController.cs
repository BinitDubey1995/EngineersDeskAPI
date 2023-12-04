using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using DatabaseProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MultipleController : ControllerBase
    {
        private readonly IMultipleEmployeeRepository _MultipleEmployeeRepository;
        //private readonly object? addedemployee;

        public MultipleController(IMultipleEmployeeRepository multipleemployeeRepository)

        {
            _MultipleEmployeeRepository = multipleemployeeRepository;
        }
        [HttpPost]

        public ActionResult AddEmployee(MultipleEmployee employee)
        {
            try
            {
                var addEmployee = _MultipleEmployeeRepository.AddEmployee(employee);
                return Ok(addEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
            [HttpDelete]
            [Route("DeleteMultipleEmployee")]
        // public  ActionResult  Delete(List<int> employeeId) ..use for List typeint
        public ActionResult Delete(string employeeId)
        {
                try
                {
                    var DeleteEmployee = _MultipleEmployeeRepository.DeleteEmployee(employeeId);
                    return Ok(DeleteEmployee);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
                }
            }
        } 
    }

