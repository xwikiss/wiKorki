using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using MaturaToBzdura.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;
using wiKorki.Data;

namespace MaturaToBzdura.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExercisesController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
      



        
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult Details(int id)
        {
            var exercise = _context.Exercises.Include(e => e.Chapter).FirstOrDefault(e => e.Id == id);
            var chapter = _context.Chapters.Include(c => c.HSClass).FirstOrDefault(c => c.Id == exercise.Chapter.Id);
            var hSClass = chapter.HSClass;

            var homeNode = new MvcBreadcrumbNode("Index", "Home", "Strona Główna");
            var hSClassNode = new MyMvcBreadcrumbNode("Details", "HSClasses", hSClass.Name, hSClass.Id) { Parent = homeNode };
            var chapterNode = new MyMvcBreadcrumbNode("Details", "Chapters", chapter.Name, chapter.Id) { Parent = hSClassNode };
            var exerciseNode = new MyMvcBreadcrumbNode("Details", "Exercises", exercise.Name, exercise.Id) { Parent = chapterNode };

            ViewData["BreadcrumbNodes"] = new List<MvcBreadcrumbNode> { homeNode, hSClassNode, chapterNode, exerciseNode };
           
            var result = _context.Exercises.First(n => n.Id == id);
            return View(result);
        }

     
    }
}
