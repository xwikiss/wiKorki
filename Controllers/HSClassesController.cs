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

namespace MaturaToBzdura.Controllers
{
    
    
    public class HSClassesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LinkGenerator _linkGenerator;
     

        public HSClassesController(AppDbContext context, LinkGenerator linkGenerator)
        {
            _context = context;
            _linkGenerator = linkGenerator;
         
        }



        public async Task<IActionResult> Details(int id)
        {
            var hSClass = await _context.HSClass.FirstOrDefaultAsync(n => n.Id == id);
            if (hSClass == null)
            {
                return NotFound();
            }

            var homeNode = new MvcBreadcrumbNode("Index", "Home", "Strona Główna");
            var klasaNode = new MyMvcBreadcrumbNode("Details", "HSClasses", hSClass.Name,hSClass.Id) { Parent = homeNode };

            ViewData["BreadcrumbNodes"] = new List<MvcBreadcrumbNode> { homeNode, klasaNode };

            var result = await _context.Chapters.Where(n => n.HSClass.Id == id).ToListAsync();

            return View(result);
        }
        public ActionResult Index()
        {
            return View();
        }
        

        // GET: KlasaLiceumsController/Create
        public ActionResult Create()
       {
            return View();
        }

        // POST: KlasaLiceumsController/Create
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

        // GET: KlasaLiceumsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KlasaLiceumsController/Edit/5
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

        // GET: KlasaLiceumsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KlasaLiceumsController/Delete/5
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
