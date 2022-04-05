﻿using System;

namespace ExCursed.WebAPI.Models.Timetable
{
    public class TimetableCreateRequest
    {
        public int GroupId { get; set; }

        public int LessonId { get; set; }

        public DateTime DateTime { get; set; }

        public bool WithZoomMeeting { get; set; }
    }
}
