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


        public IActionResult Index()
        {

            return View();
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
        [ActionName("vat-refund-in-the-uae")]

        public IActionResult VATRefund()
        {
            return View();

        }
        [ActionName("vat-compliance-in-the-uae")]

        public IActionResult VATCompliance()
        {
            return View();

        }

        [ActionName("hire-a-tax-consultant-in-dubai-uae")]

        public IActionResult TaxAgent()
        {
            return View();

        }
        [ActionName("business-growth-services-in-the-uae")]

        public IActionResult BusinessGrowth()
        {
            return View();

        }
        [ActionName("business-solutions-in-uae")]

        public IActionResult BusinessSolutions()
        {
            return View();

        }

    }
}