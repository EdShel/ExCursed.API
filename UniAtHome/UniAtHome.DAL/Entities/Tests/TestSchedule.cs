﻿using System;

namespace UniAtHome.DAL.Entities.Tests
{
    public class TestSchedule : BaseEntity
    {
        public int TestId { get; set; }

        public int GroupId { get; set; }

        public int LessonId { get; set; }

        public DateTime BeginTime { get; set; }

        public Test Test { get; set; }

        public Timetable Timetable { get; set; }
    }
}
