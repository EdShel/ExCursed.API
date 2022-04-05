﻿using System.Collections.Generic;

namespace ExCursed.DAL.Entities
{
    public class Teacher
    {
        public string UserId { get; set; }

        public int UniversityId { get; set; }

        public User User { get; set; }

        public University University { get; set; }

        public List<CourseMember> CourseMembers { get; set; }
    }
}
