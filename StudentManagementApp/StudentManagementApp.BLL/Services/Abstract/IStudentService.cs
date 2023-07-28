using StudentManagementApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.BLL.Services.Abstract
{
    public interface IStudentService
    {
        Task<Student> GetByIdAsync(Guid id);
        Task<List<Student>> GetAllAsync();
        Task<List<Student>> GetAllStudentAsFillRate();
        Task<Student> AddAsync(Student entity);
        Task DeleteAsync(Student entity);
        Task<Student> UpdateAsync(Student entity);
    }
}
