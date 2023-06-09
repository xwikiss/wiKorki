using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using MaturaToBzdura.Models;
using Microsoft.EntityFrameworkCore;
using wiKorki.Data.Base;

namespace wiKorki.Data.Services
{
    public class HSClassesService : EntityBaseRepository<HSClass>, IHSClassesService
    {
        private readonly AppDbContext _context;
        public HSClassesService(AppDbContext context) : base(context)
        {
            _context = context;
        }


        async Task<HSClass> IHSClassesService.GetHSClassByIdAsync(int id)
        {
            var hsClass = await _context.HSClasses.FirstOrDefaultAsync(n => n.Id == id);
            return hsClass;

        }

        async Task<List<Chapter>> IHSClassesService.GetHSClassesChapters(int id)
        {
           var chapters = await _context.Chapters.Where(n => n.HSClass.Id == id).ToListAsync();
           return chapters;
        }
    }
}
