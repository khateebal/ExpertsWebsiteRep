using Microsoft.AspNetCore.Mvc;
namespace ExpertsWeb.Controllers
{ 
    
    public class ServicesController : Controller
    {
        private readonly ILogger<ServicesController> _logger;
        public ServicesController(ILogger<ServicesController> logger)
        {
            _logger = logger;
        }


        [ActionName("accounting-and-bookkeeping-services")]
        public IActionResult AccountingServices()
        {
            ViewBag.CssClass = "inner-page";

			return View();
        }
        [ActionName("tax-consulting")]
        public IActionResult TaxConsulting()
        {
            return View();
        }
        [ActionName("audit-and-assurance")]

        public IActionResult AuditAndAssurance()
        {
            return View();

        }
       
    }
}