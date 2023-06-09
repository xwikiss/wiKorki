using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;

namespace MaturaToBzdura.Controllers
{
    [DefaultBreadcrumb(Title = "Strona Główna")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult RenderAboutMeView()
        {

            return View("AboutMe");
        }
        public ActionResult RenderAboutMePartial()
        {
            
            return PartialView("_AboutMe");
        }
    }
}
