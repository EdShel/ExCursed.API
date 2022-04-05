using System.Collections.Generic;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Course;
using ExCursed.BLL.DTOs.Students;

namespace ExCursed.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<CourseDTO>> GetStudentsCoursesAsync(StudentsCoursesRequest coursesRequest);

        Task<IEnumerable<GroupDTO>> GetStudentsGroupsAsync(string studentEmail);
    }
}