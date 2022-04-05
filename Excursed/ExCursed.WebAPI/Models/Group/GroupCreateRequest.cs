using System.ComponentModel.DataAnnotations;

namespace ExCursed.WebAPI.Models.Group
{
    public class GroupCreateRequest
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public string TeacherEmail { get; set; }

        [Required]
        public string GroupName { get; set; }
    }
}
