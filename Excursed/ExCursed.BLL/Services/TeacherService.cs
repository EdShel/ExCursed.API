using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Course;
using ExCursed.BLL.DTOs.Teacher;
using ExCursed.BLL.Interfaces;
using ExCursed.DAL.Entities;
using ExCursed.DAL.Interfaces;

namespace ExCursed.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        private readonly IRepository<Course> courseRepository;

        private readonly IMapper mapper;

        public TeacherService(
            ITeacherRepository teacherRepository,
            IRepository<Course> courseRepository,
            IMapper mapper)
        {
            this.teacherRepository = teacherRepository;
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }

        public async Task<TeacherInfoDTO> GetTeacherInfoAsync(string id)
        {
            var teacher = await teacherRepository.GetByIdAsync(id);
            return new TeacherInfoDTO
            {
                Id = id,
                FirstName = teacher.User.FirstName,
                LastName = teacher.User.LastName,
                UniversityId = teacher.UniversityId
            };
        }

        public async Task<TeacherInfoDTO> GetTeacherInfoByEmailAsync(string email)
        {
            var teacher = (await teacherRepository
                .Find(t => t.User.Email == email)).First();
            return await GetTeacherInfoAsync(teacher.UserId); 
        }

        public async Task<IEnumerable<CourseDTO>> GetTeahersCoursesAsync(TeachersCoursesRequest coursesRequest)
        {
            var teacherEmail = coursesRequest.TeacherEmail;

            var courses = await courseRepository.Find(
                course => course.CourseMembers.Any(
                    members => members.Teacher.User.Email == teacherEmail));

            return this.mapper.Map<IEnumerable<CourseDTO>>(courses);
        }
    }
}
