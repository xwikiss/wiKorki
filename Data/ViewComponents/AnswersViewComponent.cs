using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace wiKorki.Data.ViewComponents
{
    public class AnswersViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public AnswersViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int exerciseId)
        {
            var answers = await _context.Answers.ToListAsync();
            return View(answers);
        }
    }
}
