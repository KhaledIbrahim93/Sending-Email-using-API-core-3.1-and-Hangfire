using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using App.Command.Request;
using EmailService;
using EmailService.Repo;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangFireController : Controller
    {
        private readonly IEmailSender emailSender;
        public HangFireController(IEmailSender _emailSender)
        {
            emailSender = _emailSender;
        }
        [HttpGet]
        // GET: HangFire
        public ActionResult Index()
        {
            return Ok("Welcome from HangFire");
        }
        [HttpPost]
        [Route("[action]")]
        public  IActionResult SendEmail([FromBody] MessageRequest messageRequest)
        {
            try
            {
             var message = new Message(new string[] { messageRequest.To }, messageRequest.Content, messageRequest.Subject );
            var jobId = BackgroundJob.Enqueue(() => emailSender.SendEmail(message));
            return Ok($"Job Id {jobId} and Email Sent Successfully.... ^___^");
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
      

    }
}