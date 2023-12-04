using DatabaseProject.Helper;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Intuit.Ipp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        //private readonly object? addedemployee;

        public EmployeeController(IEmployeeRepository employeeRepository)

        {
            _EmployeeRepository = employeeRepository;
        }

        [HttpGet]

        public ActionResult GetEmployees()
        {
            try
            {
                var employees = _EmployeeRepository.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpGet]

        public ActionResult GetEmployeeById(int Id)
        {
            try
            {
                var employee = _EmployeeRepository.GetEmployeeById(Id);
                if (employee == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Not Exist");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpGet]

        public ActionResult GetEmployeeDetailById(int Id)
        {
            try
            {
                var employee = _EmployeeRepository.GetEmployeeById(Id);
                var abc = new Emp() { City = employee.City, EmployeeName = employee.EmpolyeeName };
                return Ok(abc);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }


        [HttpPost]

        public ActionResult AddEmployee(DEmployee employee)
        {
            try
            {



                if (CheckEmptyStringForName(employee.EmpolyeeName))
                {
                    return Ok("please insert name");
                }
                var addEmployee = _EmployeeRepository.AddEmployee(employee);
                return Ok(addEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddTwoTableJoin")]

        public ActionResult AddEmployee(TwoTableJoin ttj)
        {
            try
            {
                {
                    var addEmployee = _EmployeeRepository.AddEmployee(ttj);
                    return Ok(addEmployee);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        //[HttpPut]
        //[Route("UpdateDEmployee")]
        //public ActionResult Put(DEmployee employee)
        //{
        //    try
        //    {
        //        var UpdateEmployee = _EmployeeRepository.UpdateEmployee(employee);
        //        return Ok(UpdateEmployee);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
        //    }
        //}

        [HttpPut]
        [Route("UpdateDEmployee")]
        public ActionResult Put(DEmployee employee)
        {
            try
            {
                if (CheckEmptyStringForCity(employee.City))
                {
                    return Ok("please insert city");
                }
                var UpdateEmployee = _EmployeeRepository.UpdateEmployee(employee);
                return Ok(UpdateEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        //[HttpDelete]
        //[Route("DeleteDEmployee")]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var DeleteEmployee = _EmployeeRepository.DeleteEmployee(id);
        //        return Ok(DeleteEmployee);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
        //    }

        //}
        [HttpDelete]
        [Route("DeleteDEmployee")]
        public ActionResult Delete(int EmployeeId)
        {
            try
            {
                if (CheckEmptyIdForEmployeeId(EmployeeId))
                {
                    return Ok("please insert id");
                }
                var DeleteEmployee = _EmployeeRepository.DeleteEmployee(EmployeeId);
                return Ok(DeleteEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }

        }
        [HttpGet]

        public ActionResult GetEmployeeBySearchKey(string searchkey)
        {
            try
            {
                var employees = _EmployeeRepository.GetEmployeeBySearchKey(searchkey);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpDelete]
        [Route("TemporaryDeleteDEmployee")]
        public ActionResult TemporaryDelete(int id)
        {
            try
            {
                var DeleteEmployee = _EmployeeRepository.TemporaryDeleteEmployee(id);
                return Ok(DeleteEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        #region Check for string
        private bool CheckEmptyStringForName(string name)
        {
            if (name == "")
            {
                return true;
            }
            return false;
        }
        #endregion



        #region Check for string
        private bool CheckEmptyStringForCity(String? city)
        {
            if (city == "")
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Check for Id
        private bool CheckEmptyIdForEmployeeId(int EmployeeId)
        {
            if ( EmployeeId == EmployeeId)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}