using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using DatabaseProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _StudentRepository;


        public StudentController(IStudentRepository studentRepository)

        {
            _StudentRepository = studentRepository;
        }
        [HttpPost]

        public ActionResult AddSchoolStudent(SchoolStudent schoolstudent)
        {
            try
            {
                var addsubject= _StudentRepository.AddSubject(schoolstudent);
                return Ok(addsubject);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
    }
}
