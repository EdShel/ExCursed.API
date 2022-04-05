﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExCursed.BLL.DTOs.Course;
using ExCursed.BLL.Exceptions;
using ExCursed.BLL.Interfaces;
using ExCursed.DAL.Entities;
using ExCursed.DAL.Interfaces;
using ExCursed.DAL.Repositories;

namespace ExCursed.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        private readonly UserRepository userRepository;

        private readonly ITeacherRepository teacherRepository;

        private readonly IMapper mapper;

        public CourseService(
            ICourseRepository courseRepository,
            UserRepository userRepository,
            ITeacherRepository teacherRepository,
            IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.userRepository = userRepository;
            this.teacherRepository = teacherRepository;
            this.mapper = mapper;
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);
            return mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> GetCourseWithLessonsByIdAsync(int id)
        {
            var course = await courseRepository.GetCourseWithLessonsByIdAsync(id);
            return mapper.Map<CourseDTO>(course);
        }

        public async Task AddCourseAsync(CourseDTO courseDto)
        {
            var course = mapper.Map<Course>(courseDto);
            var teacherId = (await userRepository.FindByEmailAsync(courseDto.TeacherEmail)).Id;
            course.CourseMembers.Add(
                new CourseMember()
                {
                    TeacherId = teacherId
                });
            await courseRepository.AddAsync(course);
            await courseRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);
            if (course != null)
            {
                courseRepository.Remove(course);
                await courseRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByNameAsync(string name)
        {
            var courses = await courseRepository.Find(
                course => EF.Functions.Like(course.Name, $"%{name}%"));
            return courses.Select(course => mapper.Map<CourseDTO>(course));
        }

        public async Task AddCourseMemberAsync(int courseId, string teacherEmail)
        {
            bool teacherIsAlreadyAdded = courseRepository
                .GetCourseTeachers(courseId)
                .Any(t => t.User.Email == teacherEmail);
            if (teacherIsAlreadyAdded)
            {
                throw new BadRequestException("The teacher is already added!");
            }

            Teacher teacher = await teacherRepository.GetByEmailAsync(teacherEmail);
            Course course = await courseRepository.GetByIdAsync(courseId);
            if (teacher.UniversityId != course.UniversityId)
            {
                throw new BadRequestException("Teacher of another university can't be added to this course!");
            }

            await courseRepository.AddCourseMemberAsync(courseId, teacher.UserId);
            await courseRepository.SaveChangesAsync();
        }

        public async Task RemoveCourseMemberAsync(int courseId, string teacherEmail)
        {
            try
            {
                Teacher teacher = await teacherRepository.GetByEmailAsync(teacherEmail);
                await courseRepository.RemoveCourseMemberAsync(courseId, teacher.UserId);
                await courseRepository.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                throw new BadRequestException("Teacher doesn't belong to the course!");
            }
        }

        public IEnumerable<CourseMemberDTO> GetCourseMembers(int id)
        {
            return courseRepository.GetCourseTeachers(id)
                .Select(t => new CourseMemberDTO
                {
                    FirstName = t.User.FirstName,
                    LastName = t.User.LastName,
                    Email = t.User.Email
                });
        }

        public IEnumerable<GroupDTO> GetCourseGroups(int id)
        {
            return courseRepository.GetCourseGroups(id)
                .Select(g => new GroupDTO
                {
                    Id = g.Id,
                    Name = g.Name
                });
        }
    }
}
