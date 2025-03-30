using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel {

        private readonly MyDbContext _myDbContext;
        public readonly DbSet<T> _dbSet;
        public GenericRepository(MyDbContext myDbContext) {
            _myDbContext = myDbContext;
            _dbSet = _myDbContext.Set<T>();
        }

        public async Task<(IEnumerable<T> items, int totalCount, int totalPage, int currentPage, int pageSize)> GetPaginatedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate = null) {
            var query = _dbSet.AsQueryable();

            if(predicate != null) {
                query = query.Where(predicate);
            }
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            return (items, totalCount, totalCount, pageNumber, pageSize);
        }

        public async Task<IEnumerable<T>> GetAllAsync() {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id) {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<bool> AddAsync(T entity) {
            _dbSet.Add(entity);
            var result = await _myDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id) {
            var data = await GetByIdAsync(id);
            if(data == null) {
                return true;
            }
            _dbSet.Remove(data);
            return await _myDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity) {
            _dbSet.Update(entity);

            return await _myDbContext.SaveChangesAsync() > 0;
        }
    }
}
