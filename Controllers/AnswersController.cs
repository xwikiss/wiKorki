using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using MaturaToBzdura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using wiKorki.Data.Base;
using wiKorki.Data.ViewModels;
using wiKorki.Models;

namespace wiKorki.Controllers
{
    public class AnswersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEntityBaseRepository<Answer> answerRepository;

        public AnswersController(AppDbContext context, UserManager<ApplicationUser> userManager, IEntityBaseRepository<Answer> entityBaseRepository)
        {
            _context = context;
            _userManager = userManager;
            answerRepository = entityBaseRepository;
        }
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var answers = answerRepository.GetWithInclude(null,
                    a => a.ApplicationUser,
                    a => a.Exercise);

                return View("AdminIndex", answers);
            }
            else if (User.IsInRole("User"))
            {
                var curUser = await _userManager.GetUserAsync(User);
                if (curUser != null)
                {
                   
                    var answers = answerRepository.GetWithInclude(a => a.ApplicationUser.Id == curUser.Id, a => a.Exercise);
                    return View("UserIndex", answers);
                }
            }
            return NotFound();
        }


        public IActionResult GetImage(int id)
        {
            var answer = _context.Answers.FirstOrDefault(a => a.Id == id);
            if (answer != null && answer.Image != null)
            {
                return File(answer.Image, "image/jpeg"); // Change the content type according to your image type
            }
            return NotFound();
        }


        public async Task<IActionResult> Create(AddAnswerVM model, IFormFile imageFile)
        {
            ModelState.Clear();

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
