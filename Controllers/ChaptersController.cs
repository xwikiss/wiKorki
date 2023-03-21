using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SmartBreadcrumbs.Attributes;
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
        // GET: RozdzialsControllers
       
        public ActionResult Index()
        {
            return View();
        }

        // GET: RozdzialsControllers/Details/5
     
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

        // GET: RozdzialsControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RozdzialsControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RozdzialsControllers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RozdzialsControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RozdzialsControllers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RozdzialsControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
