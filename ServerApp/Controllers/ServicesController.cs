using Microsoft.AspNetCore.Mvc;
namespace ExpertsWeb.Controllers
{ 
    
    public class ServicesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
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
        [ActionName("vat-registeration-in-dubai-uae")]

        public IActionResult VATRegisteration()
        {
            return View();

        }
        [ActionName("vat-refund-in-dubai-uae")]

        public IActionResult VATRefund()
        {
            return View();

        }

        [ActionName("hire-a-tax-consultant-in-dubai-uae")]

        public IActionResult TaxAgent()
        {
            return View();

        }

    }
}