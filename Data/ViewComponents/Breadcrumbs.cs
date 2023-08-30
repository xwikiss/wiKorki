using Microsoft.AspNetCore.Mvc;

namespace MaturaToBzdura.Data.ViewComponents
{
    public class Breadcrumbs : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}