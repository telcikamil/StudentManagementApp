
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

        /// <summary>
        /// Yeni Student Ekler.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Student> AddAsync(Student entity)
        {
            entity.CalculateProfileFillRate();

            return await _studentRepository.AddAsync(entity);
        }

        /// <summary>
        /// Id si girilen Student'ı siler.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Student entity)
        {
            await _studentRepository.DeleteAsync(entity);
        }

        /// <summary>
        /// Bütün Studentları listeler.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        /// <summary>
        /// Bütün Studentları Profil doluluk oranı En yüksek olandan en az olana doğru listeler.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Student>> GetAllStudentAsFillRate()
        {
            return await _studentRepository.GetAllStudentAsFillRateAsync();
        }

        /// <summary>
        /// Id'si verilen Studentı getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Id'si verilen studentın istenen değerlerini günceller.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Student> UpdateAsync(Student entity)
        {
            return await _studentRepository.UpdateAsync(entity);
        }
    }
}
