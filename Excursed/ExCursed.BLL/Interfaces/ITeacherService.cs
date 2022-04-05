using System.Collections.Generic;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Course;
using ExCursed.BLL.DTOs.Teacher;

namespace ExCursed.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<CourseDTO>> GetTeahersCoursesAsync(TeachersCoursesRequest coursesRequest);

        Task<TeacherInfoDTO> GetTeacherInfoAsync(string id);

        Task<TeacherInfoDTO> GetTeacherInfoByEmailAsync(string email);
    }
}
