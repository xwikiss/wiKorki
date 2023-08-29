using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
