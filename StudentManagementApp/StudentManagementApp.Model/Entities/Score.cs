using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.Model.Entities
{
    public class Score : BaseEntity
    {
        public int VisaScore { get; set; }
        public int FinalScore { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

    }
}
