﻿using Microsoft.EntityFrameworkCore;
using SOPL.Web;

namespace SOPL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SdOPLDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(SdOPLDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
        public async Task AddAsync(T entity) { await _dbSet.AddAsync(entity); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(T entity) { _dbSet.Update(entity); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
