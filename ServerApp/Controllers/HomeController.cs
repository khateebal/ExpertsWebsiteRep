using ServerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ServerApp.Services.Email;
using Microsoft.AspNetCore.Identity.UI.Services;
using AspNetCore.SEOHelper.Sitemap;
using ServerApp.Route;
using Microsoft.AspNetCore.Localization;
using PhoneNumbers;

namespace ServerApp.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
		private readonly IWebHostEnvironment _env;
		private static PhoneNumberUtil _phoneUtil;
		public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, IWebHostEnvironment env)
        {
            _logger = logger;
            _emailSender = emailSender;
			_env = env;
            _phoneUtil = PhoneNumberUtil.GetInstance();
		}
       
        public IActionResult Index()
        {
		
			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}