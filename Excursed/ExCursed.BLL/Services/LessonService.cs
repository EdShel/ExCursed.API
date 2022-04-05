using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs;
using ExCursed.BLL.DTOs.Lesson;
using ExCursed.BLL.Interfaces;
using ExCursed.DAL.Entities;
using ExCursed.DAL.Interfaces;
using System.Linq;
using ExCursed.BLL.Exceptions;

namespace ExCursed.BLL.Services
{
    public class LessonService : ILessonService
    {
        private readonly IRepository<Lesson> lessonRepository;

        private readonly ICourseRepository courseRepository;

        private readonly IMapper mapper;

        public LessonService(IRepository<Lesson> lessonRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            this.lessonRepository = lessonRepository;
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }

        public async Task<LessonDTO> GetLessonByIdAsync(int id)
        {
            return mapper.Map<LessonDTO>(await lessonRepository.GetByIdAsync(id));
        }

        //temporary returning boolean
        public async Task<bool> AddLessonAsync(CreateLessonDTO createLessonDTO)
        {
            var course = await courseRepository.GetCourseByIdAsync(createLessonDTO.Lesson.CourseId);
            if (course == null)
            {
                throw new BadRequestException("The course doesn't exist!");
            }

            bool teacherBelongsToCourse = course.CourseMembers.FirstOrDefault(
                m => m.Teacher.User.Email == createLessonDTO.TeacherEmail) != null;
            if (!teacherBelongsToCourse)
            {
                throw new BadRequestException("You have to a course member!");
            }

            var lesson = mapper.Map<Lesson>(createLessonDTO.Lesson);
            await lessonRepository.AddAsync(lesson);
            await lessonRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<LessonDTO>> GetLessonsByCourseIdAsync(int id)
        {
            var lessons = await lessonRepository.Find(l => l.CourseId == id);
            return mapper.Map<IEnumerable<LessonDTO>>(lessons);
        }

        //temporary returning boolean
        public async Task<bool> DeleteLessonAsync(int id)
        {
            var lesson = await lessonRepository.GetByIdAsync(id);
            if (lesson != null)
            {
                lessonRepository.Remove(lesson);
                await lessonRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
