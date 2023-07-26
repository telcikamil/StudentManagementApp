using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.Model.Entities
{
    public class Student : BaseEntity
    {
        public Student()
        {
            Lessons = new HashSet<Lesson>();
            Scores = new HashSet<Score>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirtDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int ProfileFillRate { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Score> Scores { get; set; }


    }
}
