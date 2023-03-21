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
        public ActionResult AboutMe()
        {
            return View();
        }
    }
}
