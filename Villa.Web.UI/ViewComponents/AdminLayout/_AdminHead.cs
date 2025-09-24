using Microsoft.AspNetCore.Mvc;

namespace Villa.Web.UI.ViewComponents.AdminLayout
{
    public class _AdminHead:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
