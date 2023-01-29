using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;

namespace ExpertsWeb.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SetCulture(string id)
        {
            string culture = id;
            Response.Cookies.Append(
               CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
           );

            ViewData["Message"] = "Culture set to " + culture;

            return View("About");
        }



        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            
            
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

 
            var array = returnUrl.Split("/");
            if (array[1] == "en" || array[1] == "ar")//returnUrl like ~/en/Home/privacy
            {
                array[1] = culture.Substring(0, 2);
                return LocalRedirect(String.Join("/", array));
            }
            else// returnUrl like ~/Home/privacy
            {
                return LocalRedirect("/" + culture.Substring(0, 2) + returnUrl.Substring(1));
            }
           // return LocalRedirect(returnUrl);
        }
    }
}
