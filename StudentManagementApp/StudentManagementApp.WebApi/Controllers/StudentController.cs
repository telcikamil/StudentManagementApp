using Microsoft.AspNetCore.Mvc;
using StudentManagementApp.BLL.Services.Abstract;
using StudentManagementApp.DAL.Repositories.Abstract;
using StudentManagementApp.Model.Entities;

namespace StudentManagementApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
       
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// Studentları, Profil doluluk oranına göre listeler.
        /// </summary>
        /// <returns>Profil doluluk oranına göre sıralanmış öğrenci listesi.</returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            try
            {
                var students = await studentService.GetAllStudentAsFillRate();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Öğrenciler alınırken bir hata oluştu.");
            }
        }

        /// <summary>
        /// Yeni bir öğrenci ekler ve profil doluluk oranını hesaplar.
        /// </summary>
        /// <param name="student">Eklenecek öğrenci nesnesi.</param>
        /// <returns>Eklendiğinde geri dönen öğrenci nesnesi.</returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<Student>> AddStudent([FromForm] Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Geçersiz veri.");

                student.CalculateProfileFillRate();

                var addedStudent = await studentService.AddAsync(student);

                return addedStudent;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Öğrenci eklenirken bir hata oluştu.");
            }
        }

        /// <summary>
        /// Belirtilen Id'ye ait öğrenciyi getirir ve istenilen değerleri günceller.
        /// </summary>
        /// <param name="id">Güncellenecek öğrenci kimliği.</param>
        /// <param name="student">Güncellenmiş öğrenci nesnesi.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(Guid id, [FromForm] Student student)
        {
            try
            {
                if (id != student.Id)
                    return BadRequest("URL'deki öğrenci ID'si, veri içindeki ID ile eşleşmiyor.");

                if (!ModelState.IsValid)
                    return BadRequest("Geçersiz veri.");

                var existingStudent = await studentService.GetByIdAsync(id);
                if (existingStudent == null)
                    return NotFound();

                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.IdentityNumber = student.IdentityNumber;
                existingStudent.BirthDate = student.BirthDate;
                existingStudent.Email = student.Email;
                existingStudent.PhoneNumber = student.PhoneNumber;
                existingStudent.Address = student.Address;
                existingStudent.RegistrationDate = student.RegistrationDate;
                existingStudent.CalculateProfileFillRate();

                await studentService.UpdateAsync(existingStudent);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Öğrenci güncellenirken bir hata oluştu.");
            }
        }

        /// <summary>
        /// Belirtilen Id'ye ait öğrenciyi siler.
        /// </summary>
        /// <param name="id">Silinecek öğrenci kimliği.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(Guid id)
        {
            try
            {
                var existingStudent = await studentService.GetByIdAsync(id);
                if (existingStudent == null)
                    return NotFound();

                await studentService.DeleteAsync(existingStudent);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Öğrenci silinirken bir hata oluştu.");
            }
        }

    }
}
