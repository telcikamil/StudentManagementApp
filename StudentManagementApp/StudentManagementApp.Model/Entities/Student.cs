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

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? RegistrationDate { get; set; }

        private int? profileFillRate;
        public int? ProfileFillRate
        {
            get => profileFillRate;
            private set
            {
                if (value < 0)
                    profileFillRate = 0;
                else if (value > 100)
                    profileFillRate = 100;
                else
                    profileFillRate = value;
            }
        }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Score> Scores { get; set; }

        public void CalculateProfileFillRate()
        {
            // Toplam doldurulması gereken alan sayısı
            int totalRequiredFields = 10; 

            // Dolu olan alanların sayısını hesapla
            int filledFields = 0;
            if (!string.IsNullOrEmpty(FirstName))
                filledFields++;
            if (!string.IsNullOrEmpty(LastName))
                filledFields++;
            if (!string.IsNullOrEmpty(IdentityNumber))
                filledFields++;
            if (BirthDate != null)
                filledFields++;
            if (Height != null)
                filledFields++;
            if (Weight != null)
                filledFields++;
            if (RegistrationDate != null)
                filledFields++;
            if (!string.IsNullOrEmpty(Email))
                filledFields++;
            if (!string.IsNullOrEmpty(PhoneNumber))
                filledFields++;
            if (!string.IsNullOrEmpty(Address))
                filledFields++;

            // ProfileFillRate'i hesapla ve ayarla
            ProfileFillRate = (int)((double)filledFields / totalRequiredFields * 100);
        }
    }
}
