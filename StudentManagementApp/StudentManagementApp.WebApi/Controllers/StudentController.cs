using Microsoft.AspNetCore.Mvc;
using StudentManagementApp.DAL.Repositories.Abstract;
using StudentManagementApp.Model.Entities;

namespace StudentManagementApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            try
            {
                var students = await studentRepository.GetAllAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Öğrenciler alınırken bir hata oluştu.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(Guid id)
        {
            try
            {
                var student = await studentRepository.GetByIdAsync(id);

                if (student == null)
                    return NotFound();

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Öğrenci alınırken bir hata oluştu.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent([FromForm] Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Geçersiz veri.");

                // CalculateProfileFillRate metodunu burada çağır
                student.CalculateProfileFillRate();

                var addedStudent = await studentRepository.AddAsync(student);

                // Öğrencinin güncellenmiş ProfileFillRate değerini veritabanına kaydet
                await studentRepository.UpdateAsync(addedStudent);

                return CreatedAtAction(nameof(GetStudentById), new { id = addedStudent.Id }, addedStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Öğrenci eklenirken bir hata oluştu.");
            }
        }




        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(Guid id, [FromForm] Student student)
        {
            try
            {
                if (id != student.Id)
                    return BadRequest("URL'deki öğrenci ID'si, veri içindeki ID ile eşleşmiyor.");

                if (!ModelState.IsValid)
                    return BadRequest("Geçersiz veri.");

                var existingStudent = await studentRepository.GetByIdAsync(id);
                if (existingStudent == null)
                    return NotFound();

                // Güncelleme işlemleri yapılacak
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.IdentityNumber = student.IdentityNumber;
                existingStudent.BirthDate = student.BirthDate;
                existingStudent.Email = student.Email;
                existingStudent.PhoneNumber = student.PhoneNumber;
                existingStudent.Address = student.Address;
                existingStudent.RegistrationDate = student.RegistrationDate;
                existingStudent.Lessons = student.Lessons;
                existingStudent.BirthDate = student.BirthDate;
                existingStudent.CalculateProfileFillRate();

                await studentRepository.UpdateAsync(existingStudent); // Veritabanında güncelle

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Öğrenci güncellenirken bir hata oluştu.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(Guid id)
        {
            try
            {
                var existingStudent = await studentRepository.GetByIdAsync(id);
                if (existingStudent == null)
                    return NotFound();

                await studentRepository.DeleteAsync(existingStudent);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Öğrenci silinirken bir hata oluştu.");
            }
        }
    }
}
