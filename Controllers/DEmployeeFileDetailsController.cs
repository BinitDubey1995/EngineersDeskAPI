using DatabaseProject.DatabaseContext;
using DatabaseProject.Entity_Model;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using DatabaseProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System.Collections;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DEmployeeFileDetailsController : ControllerBase
    {
        private readonly IUsersRepository _UsersRepository;

        public DEmployeeFileDetailsController(IUsersRepository UsersRepository)
        {
            _UsersRepository = UsersRepository;
        }

        [HttpPost("PostSingleFile")]
        public ActionResult  AddPostSingleFile(IFormFile fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                
                var fileDet = new DEmployeeFileDetails()
                {
                    ID = 0,
                    FileName = fileDetails.FileName,
                    FileType = 1,
                };
                using (var stream = new MemoryStream())
                {
                    fileDetails.CopyTo(stream);
                    fileDet.FileData = stream.ToArray();
                }
              var result =  _UsersRepository.AddPostSingleFile(fileDet);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]

        public ActionResult GetFileByID(int ID)
        {
            try
            {
                var file = _UsersRepository.GetFilebyID(ID);
                if (file == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Not Exist");
                }
                Stream stream = new MemoryStream(file.FileData);
                return File(file.FileData, "application/octet-stream", file.FileName);
                //return  File(file.FileData, "application/octet-stream","ABC.pdf");
                // return Ok(file);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
    }
}
