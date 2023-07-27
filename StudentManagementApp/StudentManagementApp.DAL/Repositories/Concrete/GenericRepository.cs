using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentManagementApp.DAL.Context;
using StudentManagementApp.DAL.Repositories.Abstract;
using StudentManagementApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.DAL.Repositories.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly StudentManagementDbContext _context;
        protected readonly DbSet<T> _table;
        public GenericRepository(StudentManagementDbContext dbContext)
        {
            _context = dbContext;
            _table = _context.Set<T>();

        }
        public async Task<T> AddAsync(T entity)
        {
            var entry = await _table.AddAsync(entity);
            await _context.SaveChangesAsync(); // Değişiklikleri kaydet

            return entry.Entity;
        }


        public async Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }



        public async Task<List<T>> GetAllAsync(bool tracking = true)
        {
            var query = _table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id, bool tracking = true)
        {
            var query = _table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var updatedEntity = _table.Update(entity).Entity;
            await _context.SaveChangesAsync(); // Değişiklikleri kaydet

            return updatedEntity;
        }
    }
}
