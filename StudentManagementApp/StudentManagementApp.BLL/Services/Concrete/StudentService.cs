
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
        /// Yeni bir öğrenci ekler.
        /// </summary>
        /// <param name="entity">Eklenmek istenen öğrenci nesnesi.</param>
        /// <returns>Eklenen öğrenci nesnesi.</returns>
        public async Task<Student> AddAsync(Student entity)
        {
            // Öğrenci profili doldurma oranını hesaplar.
            entity.CalculateProfileFillRate();

            // Öğrenciyi veritabanına ekler ve eklenen öğrenci nesnesini döndürür.
            return await _studentRepository.AddAsync(entity);
        }

        /// <summary>
        /// Belirtilen Kimliğe sahip öğrenciyi siler.
        /// </summary>
        /// <param name="entity">Silinmek istenen öğrenci nesnesi.</param>
        public async Task DeleteAsync(Student entity)
        {
            // Öğrenciyi veritabanından siler.
            await _studentRepository.DeleteAsync(entity);
        }

        /// <summary>
        /// Tüm öğrencileri listeler.
        /// </summary>
        /// <returns>Tüm öğrenci listesi.</returns>
        public async Task<List<Student>> GetAllAsync()
        {
            // Tüm öğrencileri veritabanından çeker ve listeyi döndürür.
            return await _studentRepository.GetAllAsync();
        }

        /// <summary>
        /// Profil doluluk oranına göre en yüksekten en düşüğe doğru sıralanmış tüm öğrencileri listeler.
        /// </summary>
        /// <returns>Profil doluluk oranına göre sıralanmış öğrenci listesi.</returns>
        public async Task<List<Student>> GetAllStudentAsFillRate()
        {
            // Öğrencileri profillerine göre sıralayarak listeyi döndürür.
            return await _studentRepository.GetAllStudentAsFillRateAsync();
        }

        /// <summary>
        /// Kimliği verilen öğrenciyi getirir.
        /// </summary>
        /// <param name="id">Getirilmek istenen öğrenci kimliği.</param>
        /// <returns>Belirtilen kimliğe sahip öğrenci.</returns>
        public async Task<Student> GetByIdAsync(Guid id)
        {
            // Verilen kimliğe sahip öğrenciyi veritabanından çeker ve nesneyi döndürür.
            return await _studentRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Kimliği verilen öğrencinin istenen değerlerini günceller.
        /// </summary>
        /// <param name="entity">Güncellenmiş öğrenci nesnesi.</param>
        /// <returns>Güncellenmiş öğrenci nesnesi.</returns>
        public async Task<Student> UpdateAsync(Student entity)
        {
            // Öğrenciyi günceller ve güncellenen öğrenci nesnesini döndürür.
            return await _studentRepository.UpdateAsync(entity);
        }
    }
}
