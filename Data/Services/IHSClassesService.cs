using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Models;
using wiKorki.Data.Base;

namespace wiKorki.Data.Services
{
    public interface IHSClassesService : IEntityBaseRepository<HSClass>
    {
        Task<HSClass> GetHSClassByIdAsync(int id);
        Task<List<Chapter>> GetHSClassesChapters(int id);
    }
}
