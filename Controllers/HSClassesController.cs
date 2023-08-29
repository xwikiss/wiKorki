using System.Collections.Generic;
using System.Linq;
using MaturaToBzdura.Data;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Nodes;
using wiKorki.Data;

namespace MaturaToBzdura.Controllers
{
    public class HSClassesController : Controller
    {
        private readonly AppDbContext _context;
     
        public HSClassesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var hSClass = _context.HSClasses.FirstOrDefault(h => h.Id == id);
            if (hSClass == null)
            {
                return NotFound();
            }

            var homeNode = new MvcBreadcrumbNode("Index", "Home", "Strona Główna");
            var klasaNode = new MyMvcBreadcrumbNode("Details", "HSClasses", hSClass.Name,hSClass.Id) { Parent = homeNode };

            ViewData["BreadcrumbNodes"] = new List<MvcBreadcrumbNode> { homeNode, klasaNode };

            var chapters = _context.Chapters.Where(c => c.HSClassId == id).ToList();
            return View(chapters);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
