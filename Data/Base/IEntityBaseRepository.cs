using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace wiKorki.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        public IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

    }
}
