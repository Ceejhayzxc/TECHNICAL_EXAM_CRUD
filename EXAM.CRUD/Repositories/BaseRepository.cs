using EXAM.CRUD.Common;
using EXAM.CRUD.Data;
using EXAM.CRUD.Interfaces;
using EXAM.CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAM.CRUD.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly AppDbContext _db;
        protected DbSet<T> _table;

        public BaseRepository(AppDbContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            //entity.IsActive = false;
            //entity.IsDeleted = true;
            _table.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table
                .Where(r => r.IsActive == true && r.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<T?> GetOneAsync(int id)
        {
            return await _table
                .FirstOrDefaultAsync(r => r.Id == id && r.IsActive == true);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _table.Update(entity).State = EntityState.Modified;
            entity.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
