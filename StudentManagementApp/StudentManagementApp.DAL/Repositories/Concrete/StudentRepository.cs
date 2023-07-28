using Microsoft.EntityFrameworkCore;
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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentManagementDbContext dbContext) : base(dbContext) { }

        /// <summary>
        /// Profil doluluk oranına göre tüm öğrencileri en yüksekten en düşüğe doğru sıralar ve listeler.
        /// </summary>
        /// <param name="tracking">True ise takip eder, False ise takip etmez.</param>
        /// <returns>Profil doluluk oranına göre sıralanmış öğrenci listesi.</returns>
        public async Task<List<Student>> GetAllStudentAsFillRateAsync(bool tracking = true)
        {
            var query = _table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();

            // Profil doluluk oranına göre en yüksekten en düşüğe doğru sıralama yapar.
            query = query.OrderByDescending(student => student.ProfileFillRate);

            return await query.ToListAsync();
        }

    }
}
