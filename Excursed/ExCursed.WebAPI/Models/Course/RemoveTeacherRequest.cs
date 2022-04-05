using System.ComponentModel.DataAnnotations;

namespace ExCursed.WebAPI.Models.Course
{
    public class RemoveTeacherRequest
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public string TeacherEmail { get; set; }
    }
}
