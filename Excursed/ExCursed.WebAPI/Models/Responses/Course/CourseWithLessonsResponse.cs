using System;
using System.Collections.Generic;
using ExCursed.WebAPI.Models.Responses.Lesson;

namespace ExCursed.WebAPI.Models.Responses.Course
{
    public class CourseWithLessonsResponse
    {
        public CourseResponse Course { get; set; }

        public IEnumerable<LessonResponse> ListLessons { get; set; } = new List<LessonResponse>();
    }
}
