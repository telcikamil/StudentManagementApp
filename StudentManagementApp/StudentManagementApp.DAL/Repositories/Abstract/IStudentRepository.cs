using StudentManagementApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.DAL.Repositories.Abstract
{
    public interface IStudentRepository:IRepository<Student>
    {
        Task<List<Student>> GetAllStudentAsFillRateAsync(bool tracking = true);
    }
    
}
