using Microsoft.AspNetCore.Mvc;

namespace Villa.Web.UI.ViewComponents.Default_Index
{
    public class _DefaultMessage:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
