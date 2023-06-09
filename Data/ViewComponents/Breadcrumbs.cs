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
      

    }
}