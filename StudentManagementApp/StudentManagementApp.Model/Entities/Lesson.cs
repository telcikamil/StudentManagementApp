using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.Model.Entities
{
    public class Lesson : BaseEntity
    {
        public Lesson()
        {
            Students = new HashSet<Student>();
            Scores = new HashSet<Score>();
        }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
