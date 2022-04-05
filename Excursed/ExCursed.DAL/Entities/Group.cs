﻿using System.Collections.Generic;

namespace ExCursed.DAL.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }

        public List<StudentGroup> StudentGroups { get; set; }

        public int CourseMemberId { get; set; }

        public CourseMember CourseMember { get; set; }

        public List<Timetable> Timetables { get; set; }
    }
}
