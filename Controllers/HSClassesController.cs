using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;
using wiKorki.Data;
using wiKorki.Data.Services;

namespace MaturaToBzdura.Controllers
{
    
    
    public class HSClassesController : Controller
    {
        private readonly IHSClassesService _service;
        private readonly LinkGenerator _linkGenerator;
     

        public HSClassesController(IHSClassesService service, LinkGenerator linkGenerator)
        {
            _service = service;
            _linkGenerator = linkGenerator;
         
        }



        public async Task<IActionResult> Details(int id)
        {
            var hSClass = await _service.GetHSClassByIdAsync(id);
            if (hSClass == null)
            {
                return NotFound();
            }

            var homeNode = new MvcBreadcrumbNode("Index", "Home", "Strona Główna");
            var klasaNode = new MyMvcBreadcrumbNode("Details", "HSClasses", hSClass.Name,hSClass.Id) { Parent = homeNode };

            ViewData["BreadcrumbNodes"] = new List<MvcBreadcrumbNode> { homeNode, klasaNode };

            var chapters = await _service.GetHSClassesChapters(id);

            return View(chapters);
        }
        public ActionResult Index()
        {
            return View();
        }
        

    }
}
