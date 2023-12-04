using DatabaseProject.Helper;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdpartyController : ControllerBase
    {
        [HttpGet]

        public ActionResult GetEmployeeIntrigation()
        {
            try
            {
                var employeeintrigation = IntrigationService.httpcallingemployeeapi();
                return Ok(employeeintrigation);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }

        }
        //[HttpPost]

        //public ActionResult AddEmployeeIntrigation()
        //{
        //    try
        //    {
        //        var addEmployee = TPCalling.httpcallingaddemployeeapi();
        //        return Ok(addEmployee);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
        //    }
        //}
        [HttpPost]

        public ActionResult AddEmployeeIntrigation(DEmployee tpc)
        {
            try
            {
                var addEmployee = TPCalling.httpcallingaddemployeeapi(tpc);
                return Ok(addEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
    }
    }

