using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Base
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<(IEnumerable<T> items, int totalCount, int totalPage, int currentPage, int pageSize)> GetPaginatedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
