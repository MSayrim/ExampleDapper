using Example.CORE.Entities.Abstract;
using Example.CORE.Repository.Abstract.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.CORE.Repository.Concrete.EntityFrameWorkcore.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity
    {

        private readonly ApplicationDbContext _context;
        protected DbSet<T> _table;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _table = _context.Set<T>();
        }

        public async Task Add(T item)
        {
            await _table.AddAsync(item);
            await Save();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression) => await _table.AnyAsync(expression);


        public async Task Delete(T item)
        {
            _table.Remove(item);
            await Save();
        }

        public async Task<T> FirstByDefault(Expression<Func<T, bool>> expression) => await _table.Where(expression).FirstOrDefaultAsync();

        public async Task<List<T>> Get(Expression<Func<T, bool>> expression) => await _table.Where(expression).ToListAsync();

        public async Task<List<T>> GetAll() => await _table.ToListAsync();

        public async Task<T> GetByID(Guid ID) => await _table.FindAsync(ID);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            _context.Entry<T>(item).State = EntityState.Modified;
            await Save();
        }
    }
}
