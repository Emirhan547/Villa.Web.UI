using Microsoft.AspNetCore.Mvc;

namespace Villa.Web.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
