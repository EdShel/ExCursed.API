using System.Collections.Generic;

namespace ExCursed.BLL.DTOs.Course
{
    public class GroupDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<StudentModel> Students {  get; set; }
    }

    public class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
