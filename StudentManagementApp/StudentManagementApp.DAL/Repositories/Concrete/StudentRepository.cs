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

        public async Task<List<Student>> GetAllStudentAsFillRateAsync(bool tracking = true)
        {
            var query = _table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();

            // Profil doluluk oranına göre en çoktan aza sıralama yapar.
            query = query.OrderByDescending(student => student.ProfileFillRate);

            return await query.ToListAsync();

        }
    }
}
