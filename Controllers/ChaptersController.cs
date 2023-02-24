using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;

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
            //var rozdzial = _context.Rozdzials.FirstOrDefault(n => n.Id == id);
           // if (rozdzial == null)
           // {
             //   return NotFound();
          //  }
           // var klasa = _context.KlasaLiceums.FirstOrDefault(n => n.Id == rozdzial.KlasaLiceum.Id);
           // if (klasa == null)
            //{
              //  return NotFound();
           // }

           // var homeNode = new MvcBreadcrumbNode("Index", "Home", "Strona Główna");
           // var klasaNode = new MvcBreadcrumbNode("Details", "KlasaLiceums", klasa?.Nazwa ?? "Nieznana klasa") { Parent = homeNode };
            //var rozdzialNode = new MvcBreadcrumbNode("Details", "Rozdzials", rozdzial.Nazwa) { Parent = klasaNode };

           // ViewData["BreadcrumbNodes"] = new List<MvcBreadcrumbNode> { homeNode, klasaNode, rozdzialNode};

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
