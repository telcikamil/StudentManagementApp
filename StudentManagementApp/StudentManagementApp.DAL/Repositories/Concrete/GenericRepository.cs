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
        /// <summary>
        /// Yeni bir entity ekler.
        /// </summary>
        /// <param name="entity">Eklenecek entity nesnesi.</param>
        /// <returns>Eklendiğinde geri dönen entity nesnesi.</returns>
        public async Task<T> AddAsync(T entity)
        {
            var entry = await _table.AddAsync(entity);
            await _context.SaveChangesAsync(); // Değişiklikleri kaydet

            return entry.Entity;
        }

        /// <summary>
        /// Belirtilen entity'i siler.
        /// </summary>
        /// <param name="entity">Silinecek entity nesnesi.</param>
        public async Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Tüm entity'leri listeler.
        /// </summary>
        /// <param name="tracking">True ise takip eder, False ise takip etmez.</param>
        /// <returns>Tüm entity listesi.</returns>
        public async Task<List<T>> GetAllAsync(bool tracking = true)
        {
            var query = _table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        /// <summary>
        /// Belirtilen Id'ye sahip entity'yi getirir.
        /// </summary>
        /// <param name="id">Getirilecek entity'nin kimliği.</param>
        /// <param name="tracking">True ise takip eder, False ise takip etmez.</param>
        /// <returns>Belirtilen Id'ye sahip entity veya null.</returns>
        public async Task<T?> GetByIdAsync(Guid id, bool tracking = true)
        {
            var query = _table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        /// <summary>
        /// Belirtilen Id'ye sahip entity'nin istenen değerlerini günceller.
        /// </summary>
        /// <param name="entity">Güncellenecek entity nesnesi.</param>
        /// <returns>Güncellenen entity nesnesi.</returns>
        public async Task<T> UpdateAsync(T entity)
        {
            var updatedEntity = _table.Update(entity).Entity;
            await _context.SaveChangesAsync(); // Değişiklikleri kaydet

            return updatedEntity;
        }

    }
}
