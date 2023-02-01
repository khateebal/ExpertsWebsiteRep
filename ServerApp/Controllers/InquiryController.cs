using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using PhoneNumbers;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    public class InquiryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        public InquiryController(ILogger<HomeController> logger, IEmailSender emailSender, IWebHostEnvironment env)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Submit(ContactForm Form)
        {
            try
            {
                Form.MobileNumber = Form.MobileNumber ?? "";
                string Subject = "Website email from: " + Form.Email;
                string Body = "Name: " + Form.Name + "<br/>" + "Email: " + Form.Email + "<br/>" + " Mobile Number: " + Form.MobileNumber + "<br/>" + "Message: " + Form.Message;


                await _emailSender.SendEmailAsync(Form.Email, Subject, Body);

                return RedirectToAction("ThankYou");

            }

            catch (Exception e) { return StatusCode(500); }

        }
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}


