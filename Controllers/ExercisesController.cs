using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using MaturaToBzdura.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;

namespace MaturaToBzdura.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly AppDbContext _context;

        public ExercisesController(AppDbContext context)
        {
            _context = context;
        }
        // GET: ZadaniesController



        [Breadcrumb(Title = "Zadanie")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: ZadaniesController/Details/5
      
        public ActionResult Details(int id)
        {
            //var zadanie = _context.Zadanies.Where(n => n.Id == id).First();
            
            //int parentId = (int)TempData["rozdzialId"];
            //var parent = _context.Rozdzials.Where(n => n.Id == parentId).First();

            //var parentNode = new MvcBreadcrumbNode("Details", "Rozdzials", parent.Nazwa)
            //{
             //   RouteValues = new { id = parentId }
            //};
            //var zadanieNode = new MvcBreadcrumbNode("Details", "Zadanies", zadanie.Nazwa) { Parent = parentNode } ;

            //ViewData["BreadcrumbNode"] = zadanieNode;
            //ViewData["Title"] = zadanie.Nazwa;

            var result = _context.Exercises.First(n => n.Id == id);
            return View(result);
        }

        // GET: ZadaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZadaniesController/Create
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

        // GET: ZadaniesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ZadaniesController/Edit/5
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

        // GET: ZadaniesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ZadaniesController/Delete/5
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
