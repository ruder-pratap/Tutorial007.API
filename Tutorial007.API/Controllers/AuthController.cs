using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.MailService;
using Services.UserService;
using Tutorial007.Shared;

namespace Tutorial007.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private IMailService _mailService;

        public AuthController(IUserService userService, IMailService mailService)
        {
            _userService = userService;
            _mailService = mailService;
        }

        //url will be = /api/auth/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                    return Ok(result);//Status code 200
                return BadRequest(result);
            }
            return BadRequest("Some properties is not valid");//Status code 404
        }

        //url will be = /api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.LoginUserAsync(model);
                    if (result.IsSuccess)
                    {
                        /* SMTP Mail Check */
                        string mailSubject = "Welcome to Tutorial007";
                        string password = "Oati@4776";
                        string mailBody = "<h1>This mail comming from Web Application...</h1>";
                        MailMessage mailMessage = new MailMessage(model.Email, model.Email, mailSubject, mailBody);
                        mailMessage.IsBodyHtml = true;

                        SmtpClient client = new SmtpClient();
                        client.Host = "smtp.gmail.com";
                        client.Port = 465;
                        client.UseDefaultCredentials = false;
                        client.EnableSsl = false;
                        //client.
                        client.Credentials = new System.Net.NetworkCredential(model.Email, password);
                        //client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                        //client.Send(mailMessage);



                        //mail sending bypass here
                        //await client.SendMailAsync(mailMessage);
                        return Ok(result);
                    }
                    return BadRequest(result);
                }
            }
            catch(Exception ex)
            {

            }
            return BadRequest("Some properties is not valid");
        }
    }
}
