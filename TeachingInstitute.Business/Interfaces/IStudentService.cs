using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingInstitute.Model;

namespace TeachingInstitute.Business.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        bool DeleteStudent(int id);
        StudentSaveResponse SaveStudent(Student student);
        Student FillStudentForm(int id);
    }
}
