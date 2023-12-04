using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using DatabaseProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]/Action")]
    [ApiController]
    public class EmpAddController : ControllerBase
    {
        private readonly IEmployeeRepository _EmpAddRepository;
        //private readonly object? addedemployee;

        public EmpAddController(IEmployeeRepository empaddRepository)

        {
            _EmpAddRepository = empaddRepository;
        }

        [HttpPost]

        public ActionResult AddEmpAdd(EmpAdd employee)
        {
            try
            {
                var addEmployee = _EmpAddRepository.SudAddEmpAdd(employee);
                return Ok(addEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        
        }
        

        }
    }

