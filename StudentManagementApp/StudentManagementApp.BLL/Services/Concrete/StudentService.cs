
using StudentManagementApp.BLL.Services.Abstract;
using StudentManagementApp.DAL.Repositories.Abstract;
using StudentManagementApp.DAL.Repositories.Concrete;
using StudentManagementApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.BLL.Services.Concrete
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> AddAsync(Student entity)
        {
            entity.CalculateProfileFillRate();

            return await _studentRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Student entity)
        {
            await _studentRepository.DeleteAsync(entity);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<List<Student>> GetAllStudentAsFillRate()
        {
            return await _studentRepository.GetAllStudentAsFillRateAsync();
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student> UpdateAsync(Student entity)
        {
            return await _studentRepository.UpdateAsync(entity);
        }
    }
}
