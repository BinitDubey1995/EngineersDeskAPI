using DatabaseProject.Helper;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog.Formatting;
using System.Net.Mail;

namespace EngineersDeskAPI.Controllers
{
   
    public class EmailSendController : ControllerBase
    {
       

            [HttpPost]
        [Route("api/[controller]/[Action]")]
        

        public ActionResult EmailSnd(Emaildetails gmail)
            {
                try
                {
                     EmailSend.EmailSendService(gmail.To,gmail.Subject);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
                }
            }

    }
}



