using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace wiKorki.Data.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public CommentsViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int exerciseId)
        {
            var comments = await _context.Comments.Where(c => c.ExerciseId == exerciseId).Include(c => c.User).ToListAsync();
            return View(comments);
        }
    }
}
