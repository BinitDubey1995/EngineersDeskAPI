using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using DatabaseProject.Repositories;
using Intuit.Ipp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersRepository _UsersRepository;

        public UsersController(IUsersRepository UsersRepository)
        {
            _UsersRepository = UsersRepository;
        }

        [HttpPost]

        public ActionResult AddUser(Users user)
        {
            try
            {
                var addUser = _UsersRepository.AddUser(user);
                return Ok(addUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        [HttpPost]
       
        public ActionResult Verifyingmail(Verifyingmail verify)
        {
            try
            {
                var user = _UsersRepository.GetByVerifyingmail(verify);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpGet]

        public ActionResult GetByUsername(string username)
        {
            try
            {
                var user = _UsersRepository.GetByusername(username);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
       


    }
}