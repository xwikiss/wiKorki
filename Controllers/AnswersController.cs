using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wiKorki.Data.ViewModels;
using wiKorki.Models;

namespace wiKorki.Controllers
{
    public class AnswersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnswersController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var answers = await _context.Answers.Include(a => a.ApplicationUser).Include(a => a.Exercise).ToListAsync();

                return View("AdminIndex", answers);
            }
            else if (User.IsInRole("User"))
            {
                var curUser = await _userManager.GetUserAsync(User);
                var curUserId = curUser.Id.ToString();

                if (curUser != null)
                {
                    var answers = await _context.Answers.Where(a => a.ApplicationUser.Id == curUserId).Include(a => a.Exercise).ToListAsync();
                
                    return View("UserIndex", answers);
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> GetImage(int id)
        {
            var answer = await _context.Answers.FirstOrDefaultAsync(a => a.Id == id);
            if (answer != null && answer.Image != null)
            {
                return File(answer.Image, "image/jpeg");
            }
            return NotFound();
        }

        public async Task<IActionResult> Create(AddAnswerVM model, IFormFile imageFile)
        {
            ModelState.Clear();

            if (User.Identity.IsAuthenticated)
            {

                if (imageFile == null || imageFile.Length == 0)
                {
                    TempData["ErrorMessage"] = "Plik jest wymagany!";
                    return RedirectToAction("Details", "Exercises", new { id = model.ExerciseId });
                }
                else
                {
                    model.Image = await ConvertFileToByteArrayAsync(imageFile);
                }

                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = "Plik jest wymagany!";
                    return RedirectToAction("Details", "Exercises", new { id = model.ExerciseId });
                }

                var answer = new Answer
                {
                    ExerciseId = model.ExerciseId,
                    ApplicationUser = await _userManager.GetUserAsync(User),
                    Image = model.Image
                };

                _context.Answers.Add(answer);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Twoje rozwiązanie zostało przesłane. Poczekaj na ocenę.";
                return RedirectToAction("Details", "Exercises", new { id = model.ExerciseId });

            }
            else
            {

                HttpContext.Session.SetString("ReturnUrl", Url.Action("Details", "Exercises", new { id = model.ExerciseId }));
                return RedirectToAction("Login", "Account");
            }
        }

        private async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEvaluation(int answerId, string evaluation)
        {
            var answer = await _context.Answers.FindAsync(answerId);
            if (answer == null)
            {
                return NotFound();
            }
            answer.Evaluation = evaluation;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEvaluation(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);

            if (answer == null)
            {
                return NotFound();
            }

            answer.Evaluation = null;
            _context.Update(answer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAnswer(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);

            if (answer == null)
            {
                return NotFound();
            }

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
