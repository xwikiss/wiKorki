using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MaturaToBzdura.Models;
    namespace MaturaToBzdura.Data.ViewComponents
{
    public class DropdownList :ViewComponent
    {
        private readonly AppDbContext _context;

        public DropdownList(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int id)
        {
            var query =  _context.Chapters.Where(n => n.HSClass.Id == id).ToList();
            return View(query);
        }
    }
}
