using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Controllers
{
    public class ERPController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
