using System.Collections.Generic;
using ExCursed.WebAPI.Models.Responses.Course;

namespace ExCursed.WebAPI.Models.Responses
{
    public class GetCoursesResponse
    {
        public IEnumerable<CourseResponse> Courses { get; set; }
    }
}
