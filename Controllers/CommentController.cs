using System;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using MaturaToBzdura.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using wiKorki.Data.ViewModels;

namespace wiKorki.Controllers
{
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var comment = _context.Comments.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCommentVM model)
        {
            if (model.Text == null || model.Text.Length < 1)
            {
                
                return RedirectToAction("Details", "Exercises", new { id = model.ExerciseId });
            }
            
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var comment = new Comment
                    {
                        ExerciseId = model.ExerciseId,
                        Text = model.Text,
                        CreatedAt = DateTime.Now,
                        UserId = user.Id
                    };               

                    _context.Comments.Add(comment);
                    var commentId = comment.Id;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Exercises", new { id = model.ExerciseId });
                } else { 
                    HttpContext.Session.SetString("ReturnUrl", Url.Action("Details", "Exercises", new { id = model.ExerciseId }));
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Exercises", new { id = comment.ExerciseId });
        }
    }
}
