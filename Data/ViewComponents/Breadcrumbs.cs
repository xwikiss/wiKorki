using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using MaturaToBzdura.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaturaToBzdura.Data.ViewComponents
{
    public class Breadcrumbs : ViewComponent
    {
        private readonly AppDbContext _context;

        public Breadcrumbs(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
        //var klasaQuery = this._context.KlasaLiceums.Where(n => n.Id == klasaId).First();

        //if (klasaQuery == null)
        // {
        // Handle the case where no elements were found
        //return Content("No elements were found");
        // }


        // var breadcrumbTrail = new List<Breadcrumb>
        //  {
        // new Breadcrumb { Text = "Strona Główna", Url = Url.Action("Index", "KlasaLiceums") },
        // new Breadcrumb { Text = klasaQuery.Nazwa, Url = Url.Action("Details", "KlasaLiceums") },
        // new Breadcrumb { Text = "Funkcje", Url =  Url.Action("Details" , "Rozdzials")}
        //};

        // return View(klasaQuery);
        //}

    }
}