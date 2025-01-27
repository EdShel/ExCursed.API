﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Course;

namespace ExCursed.BLL.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDTO> GetCourseByIdAsync(int id);

        Task<CourseDTO> GetCourseWithLessonsByIdAsync(int id);

        Task<int> AddCourseAsync(CourseDTO course);

        Task<IEnumerable<CourseDTO>> GetCoursesByNameAsync(string name);

        //temporary returning boolean
        Task<bool> DeleteCourseAsync(int id);

        Task AddCourseMemberAsync(int courseId, string teacherEmail);

        Task RemoveCourseMemberAsync(int courseId, string teacherEmail);

        IEnumerable<CourseMemberDTO> GetCourseMembers(int id);

        IEnumerable<GroupDTO> GetCourseGroups(int id);
    }
}
