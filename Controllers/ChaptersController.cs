using System.Collections.Generic;
using System.Linq;
using MaturaToBzdura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SmartBreadcrumbs.Nodes;
using wiKorki.Data;

namespace MaturaToBzdura.Controllers
{
    public class ChaptersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LinkGenerator _linkGenerator;

        public ChaptersController(AppDbContext context, LinkGenerator linkGenerator)
        {
            _context = context;
            _linkGenerator = linkGenerator;
        }
            
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult Details(int id)
        {
            var chapter = _context.Chapters.Include(c => c.HSClass).FirstOrDefault(c => c.Id == id);

            if (chapter == null)
            {
                return NotFound();
            }

            var hSClass = chapter.HSClass;
            
            var homeNode = new MvcBreadcrumbNode("Index", "Home", "Strona Główna");
            var hSClassNode = new MyMvcBreadcrumbNode("Details", "HSClasses", hSClass.Name, hSClass.Id) { Parent = homeNode };
            var chapterNode = new MyMvcBreadcrumbNode("Details", "Chapters", chapter.Name,chapter.Id) { Parent = hSClassNode }; 
          
            ViewData["BreadcrumbNodes"] = new List<MvcBreadcrumbNode> { homeNode, hSClassNode, chapterNode};

            var result = _context.Exercises.Where(n => n.Chapter.Id == id).ToList();
            return View(result);
        }
    }
}

