using MediatR;
using Microsoft.EntityFrameworkCore;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Domain.Common;

namespace WebGame.Persistence.EF.Repository
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly DbGameContext _context;

        public BaseRepository(DbGameContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}