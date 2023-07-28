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
        /// studentService kullanarak Studentları Profil doluluk oranına göre listeler.
        /// </summary>
        /// <returns></returns>
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
        /// studentService kullanarak öğrenci ekler ve student classındaki CalculateProfileFillRate metodunu kullanarak profil doluluk oranını hesaplar. 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
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
        /// StudentService kullanarak Girilen Id ye ait studentı getirir ve istenilen değerleri günceller 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
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
                existingStudent.BirthDate = student.BirthDate;
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
        /// StudentService kullanarak Girilen Id ye ait studentı getirir ve student ı siler.
        /// </summary>
        /// <param name="id"></param>
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
