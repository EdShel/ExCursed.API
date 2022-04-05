using System;
using System.Collections.Generic;
using ExCursed.DAL.Entities.Tests;

namespace ExCursed.DAL.Entities
{
    public class Timetable
    {
        public int GroupId { get; set; }

        public int LessonId { get; set; }

        public DateTimeOffset Date { get; set; }

        public Lesson Lesson { get; set; }

        public Group Group { get; set; }

        public ZoomMeeting ZoomMeeting { get; set; }

        public List<TestSchedule> TestSchedules { get; set; }
    }
}
