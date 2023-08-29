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